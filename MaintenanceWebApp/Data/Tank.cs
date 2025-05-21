using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace MaintenanceWebApp.Data
{
    public class Tank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TankID { get; set; }

        public string TankNo { get; set; }

        public int Capacity { get; set; }

        public string InternalCoating { get; set; }

    }
}
