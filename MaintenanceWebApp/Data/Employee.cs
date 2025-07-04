using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceWebApp.Data
{
    public class Employee : IdentityUser
    {
        [PersonalData]
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [PersonalData]
        [Display(Name = "Upload Foto")]
        public string? UserPhoto { get; set; }

        //[Required(ErrorMessage = "Please enter your email!")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address format!")]
        //public override IdentityUser string Email { get; set; }

        [NotMapped] //Helper prop
        [Required]
        public string Role { get; set; }

        [NotMapped] //Helper prop
        [Required(ErrorMessage = "Please enter your email!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address format!")]
        public string EmailAddress { get; set; }
    }
}