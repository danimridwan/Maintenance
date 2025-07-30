using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceWebApp.Data
{
    public class DataSeeder
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Seed()
        {
            SeedAdminRole();
            SeedAdminUser();
        }

        public void SeedAdminRole()
        {
            if (!_dataContext.Roles.Any())
            {
                string adminRole = "Admin";

                IEnumerable<IdentityRole> roles = new List<IdentityRole>()
                {
                    new IdentityRole() {
                    Name = adminRole,
                    NormalizedName = adminRole.ToUpper(),
                    }
                };
                _dataContext.Roles.AddRange(roles);
                _dataContext.SaveChanges();
            };
        }

        public async Task SeedAdminUser()
        {
            string adminEmail = "admin@example.com"; 

            if (await _userManager.FindByEmailAsync(adminEmail) == null)
            {
                User user = new User()
                {
                    FullName = "Admin",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    PhoneNumber = "123456789",
                    Signature = null, 
                    UserPhoto = null,
                    Section = null,
                    Role = "Admin"
                };

                var result = await _userManager.CreateAsync(user, adminEmail); // Password default
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error creating admin user: {error.Description}");
                    }
                }
            }
        }
    }
}
