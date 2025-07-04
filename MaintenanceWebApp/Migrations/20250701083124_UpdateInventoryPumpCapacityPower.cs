using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventoryPumpCapacityPower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PumpCapacity",
                table: "Inventories",
                newName: "PowerUnit");

            migrationBuilder.RenameColumn(
                name: "Power",
                table: "Inventories",
                newName: "CapacityUnit");

            migrationBuilder.AddColumn<int>(
                name: "CapacityValue",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerValue",
                table: "Inventories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacityValue",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PowerValue",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "PowerUnit",
                table: "Inventories",
                newName: "PumpCapacity");

            migrationBuilder.RenameColumn(
                name: "CapacityUnit",
                table: "Inventories",
                newName: "Power");
        }
    }
}
