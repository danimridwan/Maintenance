using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MaintenanceWebApp.Pages.Inventory.Breather_Valve;

namespace MaintenanceWebApp.Data
{
    public class Pump : IInventoryItem
    {
        public string DisplayItem => $"{Brand} {Type} - Tag {Tag}";
        public string ItemId => $"{PumpID}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PumpID { get; set; }

        [Required(ErrorMessage = "Nomor Tag Pompa harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nomor Tag Pompa melebihi batas karakter (maks 25 karakter).")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Nama Pompa harus diisi.")]
        [StringLength(50, ErrorMessage = "Input Nama Pompa melebihi batas karakter (maks 50 karakter).")]
        public string Name { get; set; }

        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string? Brand { get; set; }

        [Range(1900, 2050, ErrorMessage = "Isi Tahun Pompa dengan benar (1900-2050).")]
        public int? Year { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [StringLength(25, ErrorMessage = "Input Material melebihi batas karakter (maks 25 karakter).")]
        public string? Material { get; set; }

        [StringLength(25, ErrorMessage = "Input Category melebihi batas karakter (maks 25 karakter).")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Lokasi harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Lokasi melebihi batas karakter (maks 25 karakter).")]
        public string Location { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Kapasitas Pompa dengan benar!")]
        public double? CapacityValue { get; set; }

        public string? CapacityUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Daya Pompa dengan benar!")]
        public double? PowerValue { get; set; }

        public string? PowerUnit { get; set; }

        public string? PowerDescription { get; set; }

        [StringLength(25, ErrorMessage = "Input Kode Explotion Proof melebihi batas karakter (maks 25 karakter).")]
        public string? ExplotionProofCode { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
