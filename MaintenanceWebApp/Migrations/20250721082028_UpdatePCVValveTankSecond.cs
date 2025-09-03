using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePCVValveTankSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignPressureValue",
                table: "PCVValveTanks",
                newName: "DesignPressureValue2");

            migrationBuilder.AddColumn<double>(
                name: "DesignPressureValue1",
                table: "PCVValveTanks",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignPressureValue1",
                table: "PCVValveTanks");

            migrationBuilder.RenameColumn(
                name: "DesignPressureValue2",
                table: "PCVValveTanks",
                newName: "DesignPressureValue");
        }
    }
}
