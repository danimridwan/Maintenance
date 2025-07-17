using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlowMeterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignPressureUnit",
                table: "FlowMeters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DesignPressureValue",
                table: "FlowMeters",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignPressureUnit",
                table: "FlowMeters");

            migrationBuilder.DropColumn(
                name: "DesignPressureValue",
                table: "FlowMeters");
        }
    }
}
