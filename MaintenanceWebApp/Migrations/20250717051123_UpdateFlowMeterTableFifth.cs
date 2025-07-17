using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlowMeterTableFifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowRateValue",
                table: "FlowMeters");

            migrationBuilder.AddColumn<double>(
                name: "FlowRateValueEnd",
                table: "FlowMeters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FlowRateValueFirst",
                table: "FlowMeters",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowRateValueEnd",
                table: "FlowMeters");

            migrationBuilder.DropColumn(
                name: "FlowRateValueFirst",
                table: "FlowMeters");

            migrationBuilder.AddColumn<string>(
                name: "FlowRateValue",
                table: "FlowMeters",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }
    }
}
