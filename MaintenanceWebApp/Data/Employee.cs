using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Data
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }


        [Required]
        public string Email { get; set; }

        public string JobTitle { get; set; }

        // Soft deletion flag
        public bool IsDeleted { get; set; }
    }
}