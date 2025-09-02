using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class BreatherValve : IInventoryItem
    {
        public string DisplayItem => $"{Brand} {Type} - Tank {Tank}";
        public string ItemId => $"{BreatherValveID}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BreatherValveID { get; set; }

        [Required(ErrorMessage = "Tangki harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Tangki melebihi batas karakter (maks 25 karakter).")]
        public string Tank { get; set; }

        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string? Brand { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [StringLength(25, ErrorMessage = "Input Material melebihi batas karakter (maks 25 karakter).")]
        public string? Material { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Diameter Valve dengan benar!")]
        public double? DiameterValue { get; set; }

        public string? DiameterUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain (Positif) dengan benar!")]
        public double? DesignPressurePos { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain (Negatif) dengan benar!")]
        public double? DesignPressureNeg { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Isi nilai Kuantitas Breather Valve dengan benar!")]
        public int? Quantity { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}