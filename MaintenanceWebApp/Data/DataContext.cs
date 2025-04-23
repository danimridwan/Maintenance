using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceWebApp.Data
{
    public class DataContext : IdentityDbContext
    {
        // Add Employee and Designation entities to the DataContext class,
        // so that Entity Framework Core can create database tables for them.
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
