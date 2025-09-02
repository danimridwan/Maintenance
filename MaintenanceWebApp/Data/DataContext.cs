using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MaintenanceWebApp.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<PPMTask> PPMTasks { get; set; }
        public DbSet<PPMTaskHistory> PPMTaskHistory { get; set; }
        public DbSet<InventoryMaintenanceHistory> InventoryMaintenanceHistory { get; set; }

        //Inventory
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<ElectricPanel> ElectricPanels { get; set; }
        public DbSet<IT> IT { get; set; }
        public DbSet<FlowMeter> FlowMeters { get; set; }
        public DbSet<Valve> Valves { get; set; }
        public DbSet<PRVValve> PRVValves { get; set; }
        public DbSet<PCVValveTank> PCVValveTanks { get; set; }
        public DbSet<BreatherValve> BreatherValves { get; set; }


        //Define View
        public DbSet<PPMStatusByYear> PPMStatusByYears { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Generate View
            modelBuilder.Entity<PPMStatusByYear>()
                .ToView(nameof(PPMStatusByYears))
                .HasKey(t => t.RowNum);
        }
    }
}
