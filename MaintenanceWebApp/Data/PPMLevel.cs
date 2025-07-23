using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PPMLevel
    {
        [Key]
        public int LevelID { get; set; }

        public string? RoleName { get; set; }

        public string Status { get; set; }
    }
}
