using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePCVValveTankTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignPressureValue1",
                table: "PCVValveTanks");

            migrationBuilder.DropColumn(
                name: "DesignPressureValue2",
                table: "PCVValveTanks");

            migrationBuilder.AddColumn<string>(
                name: "DesignPressureValue",
                table: "PCVValveTanks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignPressureValue",
                table: "PCVValveTanks");

            migrationBuilder.AddColumn<double>(
                name: "DesignPressureValue1",
                table: "PCVValveTanks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DesignPressureValue2",
                table: "PCVValveTanks",
                type: "float",
                nullable: true);
        }
    }
}
