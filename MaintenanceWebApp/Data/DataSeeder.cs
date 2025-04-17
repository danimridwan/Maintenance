// Create a class to seed the Admin user with a default username/email and password

using Microsoft.AspNetCore.Identity;

namespace MaintenanceWebApp.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminRole = "Admin";
            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@123";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }

}
