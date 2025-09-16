using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace MaintenanceWebApp.Data
{
    public class Tank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TankID { get; set; }

        [Required(ErrorMessage = "Nomor Tangki harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nomor Tangki melebihi batas karakter (maks 25 karakter).")]
        public string TankNo { get; set; }

        [Required(ErrorMessage = "Kapasitas harus diisi.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Material harus diisi.")]
        [StringLength(50, ErrorMessage = "Input Material melebihi batas karakter (maks 50 karakter).")]
        public string Material { get; set; }

        [StringLength(50, ErrorMessage = "Input Internal Coating melebihi batas karakter (maks 50 karakter).")]
        public string? InternalCoating { get; set; }

        public string? Image { get; set; }

    }
}
