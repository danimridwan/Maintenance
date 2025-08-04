using MaintenanceWebApp.Data; // Pastikan User Anda ada di sini
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceWebApp.Services
{
    public class ChangePasswordResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; } = Enumerable.Empty<IdentityError>();
    }

    public class IdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User?> GetCurrentUserAsync(System.Security.Claims.ClaimsPrincipal userPrincipal)
        {
            return await _userManager.GetUserAsync(userPrincipal);
        }

        public async Task<bool> HasPasswordAsync(User user)
        {
            return await _userManager.HasPasswordAsync(user);
        }

        public async Task<ChangePasswordResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return new ChangePasswordResult { Succeeded = result.Succeeded, Errors = result.Errors };
        }

        public async Task RefreshSignInAsync(User user)
        {
            await _signInManager.RefreshSignInAsync(user);
        }
    }
}