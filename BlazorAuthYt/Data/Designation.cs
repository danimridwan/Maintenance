using System.ComponentModel.DataAnnotations;

namespace BlazorAuthYt.Data
{
    public class Designation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string DesignationName { get; set; }
    }
}
