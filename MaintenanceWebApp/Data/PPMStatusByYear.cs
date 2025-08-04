using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class PPMStatusByYear
    {
        [Key]
        public int RowNum { get; set; }
        public int Tasks { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
    }
}
