using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceWebApp.Data
{
    public class DataContext : IdentityDbContext
    {
        // Add Employee and Designation entities to the DataContext class,
        // so that Entity Framework Core can create database tables for them.
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        //Inventory
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<BreatherValve> BreatherValves { get; set; }
        public DbSet<PRValveTank> PRValveTanks { get; set; }
        public DbSet<PRValvePump> PRValvePumps { get; set; }
        public DbSet<PCValveTank> PCValveTanks { get; set; }
        public DbSet<Valve> Valves { get; set; }
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<FlowMeter> FlowMeters { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<IT> ITs { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
