using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PPMTaskHistory
    {
        [Key]
        public string TaskID { get; set; } = Guid.NewGuid().ToString();

        public string PPMID { get; set; }

        public string UpdateBy { get; set; }

        public string UpdateType { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DateUpdated { get; set; }

        public enum PPMUpdateType
        {
            Request,
            ApprovedByManager,
            ApprovedByTerminalManager,
            AssignByMaintenanceSupervisor,
            ReportingByMaintenance,
            CheckingByRequester,
            Completed,
            RejectedByManager,
            RejectedByTerminalManager
        }
    }
}
