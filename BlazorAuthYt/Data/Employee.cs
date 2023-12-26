using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAuthYt.Data
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int DesignationID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal BasicSalary { get; set; }

        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        // Navigation property for the Designation relationship
        [ForeignKey("DesignationID")]
        public Designation Designation { get; set; }

        // Soft deletion flag
        public bool IsDeleted { get; set; }
    }
}