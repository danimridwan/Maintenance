using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace MaintenanceWebApp.Data


{

    public class FileViewModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
    }

    public abstract class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InventoryID { get; set; }

        public string? Name { get; set; }

        public string Location { get; set; } = null;

        public string Material { get; set; } = null;

        public string Brand { get; set; } = null;

        public string Type { get; set; } = null;//discriminator

        public virtual Tank Tank { get; set; }

        public int? TankId { get; set; } = null;//foreign key

        public string? Photo { get; set; } = null;

        public string? Description { get; set; }
    }

    public class BreatherValve : Inventory
    {
        public int Mmh20Plus { get; set; }

        public int Mmh20Minus { get; set; }

        public int BreatherValveDiameter { get; set; }
    }

    public class PRValveTank : Inventory
    {
        public int PRVValveTankDesignedPressure { get; set; }

        public int PRValveTankDiameter { get; set; }
    }

    public class PRValvePump : Inventory
    {
        public int PRVValvePumpDesignedPressure { get; set; }

        public int PRValvePumpDiameter { get; set; }
    }

    public class PCValveTank : Inventory
    {
        public int PCValveTankDesignedPressure { get; set; }

        public int PCValveTankDiameter { get; set; }
    }

    public class Valve : Inventory
    {
        public string Pipeline { get; set; }

        public int ValveDiameter { get; set; }

        public string Layer { get; set; }

        public int TotalUnit { get; set; }
    }

    public class Pump : Inventory
    {
        public string PumpTag { get; set; }

        public string CategoryType { get; set; }

        public int Year { get; set; }

        public int CapacityValue { get; set; }

        public string CapacityUnit { get; set; }

        public int? PowerValue { get; set; }

        public string? PowerUnit { get; set; }

        public string ExplotionProofCode { get; set; }
    }

    public class FlowMeter : Inventory
    {
        public string FLowMeterTag { get; set; }

        public int FlowMeterTemperatureDesigned { get; set; }

        public int FlowMeterPressureDesigned { get; set; }

        public int FlowMeterRate { get; set; }
    }

    public class Panel : Inventory
    {
        public string Capacity { get; set; }
    }

    public class IT : Inventory
    {
        public string DeviceModel { get; set; }
    }
}