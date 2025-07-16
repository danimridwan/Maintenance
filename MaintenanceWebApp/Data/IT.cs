using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class IT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }

        [Required(ErrorMessage = "Nama Device harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nama Device melebihi batas karakter (maks 25 karakter).")]
        public string Device { get; set; }

        [Required(ErrorMessage = "Merk harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Model melebihi batas karakter (maks 25 karakter).")]
        public string Model { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
