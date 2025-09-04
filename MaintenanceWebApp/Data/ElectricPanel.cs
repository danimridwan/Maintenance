using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaintenanceWebApp.Pages.Inventory.Breather_Valve;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MaintenanceWebApp.Data
{
    public class ElectricPanel : IInventoryItem
    {
        public string DisplayItem => $"{Name} - Lokasi {Location}";
        public string ItemId => $"{PanelID}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PanelID { get; set; }

        [Required(ErrorMessage = "Nama Panel Listrik harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Nama Panel Listrik melebihi batas karakter (maks 25 karakter).")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lokasi harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Lokasi melebihi batas karakter (maks 25 karakter).")]
        public string Location { get; set; }

        public string? CapacityValue { get; set; }

        public string? CapacityUnit { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
