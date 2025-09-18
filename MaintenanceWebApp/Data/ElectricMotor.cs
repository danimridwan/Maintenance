using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class ElectricMotor
    {
        public string DisplayItem => $"{Brand} {Type}";
        public string ItemId => $"{ElectricMotorID}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ElectricMotorID { get; set; }

        [Required(ErrorMessage = "Merk harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string Brand { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Daya dengan benar!")]
        public double? Power { get; set; }

        [StringLength(10, ErrorMessage = "Input Unit Daya melebihi batas karakter (maks 10 karakter).")]
        public string? PowerUnit { get; set; }

        [StringLength(10, ErrorMessage = "Input Insulation Class melebihi batas karakter (maks 10 karakter).")]
        public string? InsulationClass { get; set; }

        [StringLength(50, ErrorMessage = "Input Protection Class melebihi batas karakter (maks 50 karakter).")]
        public string? ProtectionClass { get; set; }

        [StringLength(50, ErrorMessage = "Input Bearing melebihi batas karakter (maks 25 karakter).")]
        public string? Bearing { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
