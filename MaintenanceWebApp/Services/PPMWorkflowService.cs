using MaintenanceWebApp.Data;
using MaintenanceWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaintenanceWebApp.Services
{
    public class PPMWorkflowService
    {
        private readonly DataContext _dbContext;
        private readonly NotificationService _notificationService; // Untuk logging internal

        public PPMWorkflowService(DataContext dbContext, NotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
        }

        // Metode untuk memproses persetujuan/penyelesaian PPM
        public async Task<ServiceResult> ProcessPPMAction(PPMTask ppmTaskUpdates, ClaimsPrincipal currentUser, string actionType)
        {
            var ppm = await _dbContext.PPMTasks.FirstOrDefaultAsync(p => p.TaskID == ppmTaskUpdates.TaskID);
            if (ppm == null)
            {
                return ServiceResult.Failure("Tugas PPM tidak ditemukan.");
            }

            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? currentUser.FindFirst("Id")?.Value;
            if (string.IsNullOrEmpty(currentUserId))
            {
                return ServiceResult.Failure("ID pengguna tidak dapat ditemukan.");
            }

            PPMStatusLevel currentStatus = ppm.Level;
            PPMStatusLevel nextStatus = currentStatus; // Default: tidak ada perubahan status

            try
            {
                switch (actionType)
                {
                    case "Approve":
                        if (currentUser.IsInRole("Manager") && currentStatus == PPMStatusLevel.Request)
                        {
                            nextStatus = PPMStatusLevel.ApprovedByManager;
                        }
                        else if (currentUser.IsInRole("Terminal Manager") && currentStatus == PPMStatusLevel.ApprovedByManager)
                        {
                            nextStatus = PPMStatusLevel.ApprovedByTerminalManager;
                            ppm.TargetDate = ppmTaskUpdates.TargetDate; // Update TargetDate
                        }
                        else if (currentUser.IsInRole("Maintenance Supervisor") && currentStatus == PPMStatusLevel.ApprovedByTerminalManager)
                        {
                            nextStatus = PPMStatusLevel.OnProgress;
                            ppm.MaintenanceCategory = ppmTaskUpdates.MaintenanceCategory;
                            ppm.MaintenancePIC = ppmTaskUpdates.MaintenancePIC;

                            if (string.IsNullOrEmpty(ppm.MaintenanceCategory) || string.IsNullOrEmpty(ppm.MaintenancePIC))
                            {
                                return ServiceResult.Failure("Kategori Maintenance dan PIC Maintenance wajib diisi.");
                            }
                        }
                        else if (currentUser.IsInRole("Supervisor") && currentStatus == PPMStatusLevel.Checking)
                        {
                            nextStatus = PPMStatusLevel.Completed;
                        }
                        else if (currentUser.IsInRole("Maintenance") && currentStatus == PPMStatusLevel.OnProgress)
                        {
                            nextStatus = PPMStatusLevel.Checking;
                            ppm.EvaluationNote = ppmTaskUpdates.EvaluationNote;
                            ppm.MTDNote = ppmTaskUpdates.MTDNote;
                            ppm.TargetCompletion = ppmTaskUpdates.TargetCompletion;
                            ppm.ImageAfter = ppmTaskUpdates.ImageAfter;

                            // Validasi: Foto akhir mungkin wajib
                            if (string.IsNullOrWhiteSpace(ppm.ImageAfter))
                            {
                                return ServiceResult.Failure("Foto kondisi akhir wajib diunggah.");
                            }
                        }
                        else
                        {
                            return ServiceResult.Failure("Aksi 'Approve' tidak diizinkan untuk peran atau status PPM saat ini.");
                        }
                        break;

                    case "Reject": // Tambahkan logika untuk penolakan
                        // Peran yang bisa menolak dan dari status mana
                        if ((currentUser.IsInRole("Manager") && currentStatus == PPMStatusLevel.Request) ||
                            (currentUser.IsInRole("Terminal Manager") && currentStatus == PPMStatusLevel.ApprovedByManager) ||
                            (currentUser.IsInRole("Maintenance Supervisor") && currentStatus == PPMStatusLevel.ApprovedByTerminalManager) ||
                            (currentUser.IsInRole("Supervisor") && currentStatus == PPMStatusLevel.Checking))
                        {
                            nextStatus = PPMStatusLevel.Rejected;
                            ppm.RejectionNote = ppmTaskUpdates.RejectionNote; // Asumsikan ada input alasan penolakan
                        }
                        else
                        {
                            return ServiceResult.Failure("Aksi 'Reject' tidak diizinkan untuk peran atau status PPM saat ini.");
                        }
                        break;

                    default:
                        return ServiceResult.Failure("Jenis aksi tidak dikenal.");
                }

                ppm.Level = nextStatus;
                //ppm.LastModifiedBy = currentUserId;
                //ppm.LastModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                return ServiceResult.Success("PPM Task berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                _notificationService.LogMessage($"Kesalahan saat memproses aksi PPM Task {ppm.TaskID} ({actionType}): {ex.Message}\nStackTrace: {ex.StackTrace}");
                return ServiceResult.Failure("Terjadi kesalahan saat memproses PPM. Silakan coba lagi atau hubungi administrator.");
            }
        }
    }

    // Helper class untuk hasil service
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public static ServiceResult Success(string message = null) => new ServiceResult { IsSuccess = true, ErrorMessage = message ?? "Operasi berhasil." };
        public static ServiceResult Failure(string errorMessage) => new ServiceResult { IsSuccess = false, ErrorMessage = errorMessage };
    }
}