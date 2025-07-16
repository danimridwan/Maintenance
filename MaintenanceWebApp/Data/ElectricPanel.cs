using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceWebApp.Data
{
    public class ElectricPanel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PanelID { get; set; }

        [Required(ErrorMessage = "Nama Panel Listrik harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nama Panel Listrik melebihi batas karakter (maks 25 karakter).")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lokasi harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Lokasi melebihi batas karakter (maks 25 karakter).")]
        public string Location { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Kapasitas Panel Listrik dengan benar!")]
        public double? CapacityValue { get; set; }

        public string? CapacityUnit { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
