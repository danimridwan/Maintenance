using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PPMTask
    {
        // Ini adalah Primary Key untuk tabel PPMTask
        [Key]
        public string TaskID { get; set; } = Guid.NewGuid().ToString();

        // Ini adalah ID PPM yang mungkin ditampilkan kepada pengguna atau untuk identifikasi lainnya
        // yang Anda ingin pisahkan dari TaskID.
        public string PPMID { get; set; } = string.Empty;

        public string JobCategory { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string ImageBefore { get; set; } = string.Empty; // Path relatif ke file gambar
        public string Document { get; set; } = string.Empty; // Path relatif ke file dokumen

        // Status PPM, menggunakan enum yang baru
        public PPMStatusLevel Level { get; set; } = PPMStatusLevel.Request; // Defaultnya adalah Request (0)

        public int? Priority { get; set; }

        // Detail Pelaksanaan (diisi oleh peran selanjutnya)
        public DateOnly? TargetDate { get; set; } // Tanggal target penyelesaian
        public DateTime? MaintenanceCompletionDate { get; set; }
        public bool? TargetCompletion { get; set; } // Kesesuaian terhadap target
        public DateTime? CompletionDate { get; set; }
        public string MTDNote { get; set; } = string.Empty; // Catatan Maintenance Task Detail
        public string EvaluationNote { get; set; } = string.Empty; // Evaluasi pelaksanaan
        public string ImageAfter { get; set; } = string.Empty; // Path relatif ke file gambar

        // Informasi Penugasan Maintenance
        public string MaintenanceCategory { get; set; } = string.Empty;
        public string MaintenancePIC { get; set; } = string.Empty; // ID Employee PIC Maintenance

        // Info Pemohon (dari model Employee)
        public string CreatedBy { get; set; } = string.Empty; // ID Employee yang membuat request
        public string PPMSection { get; set; } = string.Empty; // Section pemohon
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string? RequestorNote { get; set; } = string.Empty; // Catatan Pemohon

        // Info Audit
        public string? RejectionNote { get; set; } // Catatan jika PPM ditolak
    }
}