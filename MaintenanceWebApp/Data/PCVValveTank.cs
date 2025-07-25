﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PCVValveTank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PCVValveTankID { get; set; }

        [Required(ErrorMessage = "Nomor Pompa harus diisi.")]
        [Range(1, int.MaxValue, ErrorMessage = "Isi Nomor Pompa dengan benar!")]
        public int PumpNumber { get; set; }

        [StringLength(25, ErrorMessage = "Input Merk melebihi batas karakter (maks 25 karakter).")]
        public string? Brand { get; set; }

        [StringLength(25, ErrorMessage = "Input Tipe melebihi batas karakter (maks 25 karakter).")]
        public string? Type { get; set; }

        [StringLength(25, ErrorMessage = "Input Material melebihi batas karakter (maks 25 karakter).")]
        public string? Material { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Diameter Valve dengan benar!")]
        public double? DiameterValue { get; set; }

        public string? DiameterUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain dengan benar!")]
        public double? DesignPressureValue1 { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Isi nilai Tekanan Desain dengan benar!")]
        public double? DesignPressureValue2 { get; set; }

        public string? DesignPressureUnit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Isi nilai Kuantitas PCV Valve Tank dengan benar!")]
        public int? Quantity { get; set; }

        public string? Image { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
