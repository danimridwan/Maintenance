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

        public string PPMID { get; set; }

        public string PPMSection { get; set; }

        public int Level { get; set; }
        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Deskripsi Pekerjaan harus diisi.")]
        [StringLength(250, ErrorMessage = "Input Deskripsi Pekerjaan melebihi batas karakter (maks 250 karakter).")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Jenis Pekerjaan harus diisi.")]
        public string JobCategory { get; set; }

        public string? ImageBefore { get; set; }

        public string? Document { get; set; }

        [StringLength(150, ErrorMessage = "Input Catatan Reject melebihi batas karakter (maks 150 karakter).")]
        public string? RejectionNote { get; set; }

        public DateOnly? TargetDate { get; set; }

        public string? MaintenanceCategory { get; set; }

        public string? MaintenancePIC { get; set; }

        public string? ImageAfter { get; set; }

        public bool? TargetCompletion { get; set; }

        [StringLength(250, ErrorMessage = "Input Catatan MTD melebihi batas karakter (maks 250 karakter).")]
        public string? MTDNote { get; set; }

        [StringLength(150, ErrorMessage = "Input Catatan Evaluasi melebihi batas karakter (maks 150 karakter).")]
        public string? EvaluationNote { get; set; }

        [StringLength(150, ErrorMessage = "Input Catatan Pemohon melebihi batas karakter (maks 150 karakter).")]
        public string? RequestorNote { get; set; }
    }
}
