using MaintenanceWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceWebApp.Areas.Identity.Pages.Account
{
    // Halaman model untuk fungsionalitas login.
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        // Properti yang diikat dari form input.
        [BindProperty]
        public InputModel Input { get; set; }

        // URL kembali setelah login berhasil.
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Dipanggil saat halaman diakses dengan metode HTTP GET.
        /// </summary>
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/Dashboard");
        }

        /// <summary>
        /// Dipanggil saat formulir login disubmit dengan metode HTTP POST.
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/Dashboard");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password,
                    isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    // Menambahkan pesan kesalahan yang ramah pengguna.
                    ModelState.AddModelError(string.Empty, "Email atau kata sandi tidak valid. Silakan coba lagi.");
                    return Page();
                }
            }
            catch (Exception)
            {
                // Menangani kesalahan tak terduga.
                // FIX ME: Tambahkan logging yang lebih spesifik untuk produksi.
                ModelState.AddModelError(string.Empty, "Terjadi kesalahan saat mencoba masuk. Silakan coba lagi.");
                return Page();
            }
        }

        /// <summary>
        /// Model input untuk data formulir login.
        /// </summary>
        public class InputModel
        {
            [Required(ErrorMessage = "Email harus diisi.")]
            [EmailAddress(ErrorMessage = "Format email tidak valid.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Kata sandi harus diisi.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}