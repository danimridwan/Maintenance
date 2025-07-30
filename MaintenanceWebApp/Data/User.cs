using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceWebApp.Data
{
    public class User : IdentityUser
    {

        [PersonalData]
        [Required(ErrorMessage = "Nama Lengkap harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama Lengkap tidak boleh melebihi 100 karakter.")]
        public string FullName { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "Role harus diisi.")]
        public string Role { get; set; }

        [PersonalData]
        public string? Section { get; set; }

        [PersonalData]
        public string? RoleCategory { get; set; }

        [PersonalData]
        public string? Signature { get; set; }

        [PersonalData]
        public string? UserPhoto { get; set; }
    }
}