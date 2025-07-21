// Create a class to seed the Admin user with a default username/email and password

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceWebApp.Data
{
    //public static class DataSeeder
    //{
    //    public static async Task SeedAdminUser(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        string adminRole = "Admin";
    //        string adminEmail = "admin@example.com";
    //        string adminPassword = "Admin@123";

    //        if (await roleManager.FindByNameAsync(adminRole) == null)
    //        {
    //            await roleManager.CreateAsync(new IdentityRole(adminRole));
    //        }

    //        if (await userManager.FindByNameAsync(adminEmail) == null)
    //        {
    //            Employee admin = new Employee
    //            {
    //                UserName = adminEmail,
    //                Email = adminEmail,
    //            };

    //            IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
    //            if (result.Succeeded)
    //            {
    //                await userManager.AddToRoleAsync(admin, adminRole);
    //            }
    //        }
    //    }
    //}

    public class DataSeeder
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(DataContext dataContext, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
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
            if (!_dataContext.Employees.Any())
            {
                string adminEmail = "admin@example.com";
                string adminPassword = "Admin@123";

                Employee employee = new Employee()
                {
                    FullName = "Admin",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };
                await _userManager.CreateAsync(employee, adminPassword);
                var adminUser = await _userManager.FindByNameAsync(adminEmail);
                await _userManager.AddToRoleAsync(employee, "Admin");
            };
        }
    }
}
