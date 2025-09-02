using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceWebApp.Data
{
    public class InventoryMaintenanceHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public string InventoryName { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime MaintenanceDate { get; set; }

        [StringLength(50, ErrorMessage = "Kategori Maintenance maksimal 50 karakter")]
        public string MaintenanceCategory { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Photo { get; set; }

        [StringLength(100, ErrorMessage = "Teknisi maksimal 100 karakter")]
        public string Technician { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string? PPMId { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
