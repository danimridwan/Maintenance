using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceWebApp.Data
{
    public class Valve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ValveID { get; set; }

        [Required(ErrorMessage = "Lokasi harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Lokasi melebihi batas karakter (maks 25 karakter).")]
        public string Location { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [StringLength(25, ErrorMessage = "Input Material melebihi batas karakter (maks 25 karakter).")]
        public string? Material { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Diameter Valve dengan benar!")]
        public double? DiameterValue { get; set; }

        public string? DiameterUnit { get; set; }

        [StringLength(25, ErrorMessage = "Input Jalur Valve melebihi batas karakter (maks 25 karakter).")]
        public string? ValveTrack { get; set; }

        [StringLength(25, ErrorMessage = "Input Jalur Awal Valve melebihi batas karakter (maks 25 karakter).")]
        public string? ValveEntry { get; set; }

        [StringLength(25, ErrorMessage = "Input Jalur Akhir Valve melebihi batas karakter (maks 25 karakter).")]
        public string? ValveExit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Isi nilai Kuantitas Valve dengan benar!")]
        public int? Quantity { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
