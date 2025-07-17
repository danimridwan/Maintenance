using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addFlowMeterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowMeters",
                columns: table => new
                {
                    FlowMeterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlowRateValue = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FlowRateUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempDesign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowMeters", x => x.FlowMeterID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowMeters");
        }
    }
}
