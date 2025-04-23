using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class MaintenanceTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TaskID { get; set; }

        [Required]
        public string Requestor { get; set; }

        [Required]
        public string Division { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.InProgress; //default val

        public string Photo { get; set; } = string.Empty;

        public string SupportingDocument { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
        
        [Required]
        public string WorkType { get; set; }

        // Navigation property for the Employee relationship, allow null at first creating data
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Employee Employee { get; set; }

        // Soft deletion flag
        public bool IsDeleted { get; set; }
    }

    public enum StatusEnum
    {
        InProgress,
        Completed,
        CompletedwithNotes
    }
}