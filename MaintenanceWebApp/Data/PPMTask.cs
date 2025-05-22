using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PPMTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TaskID { get; set; }

        [Required]
        public string Requestor { get; set; }

        [Required]
        public string Division { get; set; }

        [Required]
        public string JobDesc { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Request; //default val

        public string Photo { get; set; } = string.Empty;
        public string CompletePhoto { get; set; } = string.Empty;

        public string SupportingDocument { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public string RequestorNotes { get; set; } = string.Empty;

        public bool TargetCompletion { get; set; }

        public string Evaluation { get; set; } = string.Empty;

        [Required]
        public string WorkType { get; set; }

        // Navigation property for the Employee relationship, allow null at first creating data
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Employee? Employee { get; set; }

        // Soft deletion flag
        public bool IsDeleted { get; set; }
    }
    public enum StatusEnum
    {
        Request,
        InProgress,
        Completed,
        CompletedwithNotes
    }

}
