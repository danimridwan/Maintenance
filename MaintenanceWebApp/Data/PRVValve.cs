using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MaintenanceWebApp.Pages.Inventory.Breather_Valve;

namespace MaintenanceWebApp.Data
{
    public class PRVValve : IInventoryItem
    {
        public string DisplayItem => $"{Brand} {Type} - Tank {TankNumber}";
        public string ItemId => $"{PRVValveID}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PRVValveID { get; set; }

        [Required(ErrorMessage = "Kategori PRV Valve harus diisi.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Nomor Tangki harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nomor Tangki melebihi batas karakter (maks 25 karakter).")]
        public string TankNumber { get; set; }

        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string? Brand { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Diameter Valve dengan benar!")]
        public double? DiameterValue { get; set; }

        public string? DiameterUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain dengan benar!")]
        public double? DesignPressureValue { get; set; }

        public string? DesignPressureUnit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Isi nilai Kuantitas PRV Valve dengan benar!")]
        public int? Quantity { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
