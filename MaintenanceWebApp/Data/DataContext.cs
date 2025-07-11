using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceWebApp.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PPMTask> PPMTasks { get; set; }

        //Inventory
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Pump> Pumps { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
