using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class FlowMeter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlowMeterID { get; set; }

        [Required(ErrorMessage = "Nomor Tag Flow Meter harus diisi.")]
        public int Tag { get; set; }

        [StringLength(25, ErrorMessage = "Input Merk Flow Meter melebihi batas karakter (maks 25 karakter).")]
        public string? Brand { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe Flow Meter melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Lokasi harus diisi.")]
        [StringLength(25, ErrorMessage = "Input Lokasi melebihi batas karakter (maks 25 karakter).")]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "Input Deskripsi melebihi batas karakter (maks 100 karakter).")]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Desain Laju Alir dengan benar!")]
        public double? FlowRateValueFirst { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Desain Laju Alir dengan benar!")]
        public double? FlowRateValueEnd { get; set; }
        public string? FlowRateUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain dengan benar!")]
        public double? DesignPressureValue { get; set; }

        public string? DesignPressureUnit { get; set; }

        public string? TempDesign { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
