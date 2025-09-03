using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valves",
                columns: table => new
                {
                    ValveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DiameterValue = table.Column<double>(type: "float", nullable: true),
                    DiameterUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValveTrack = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ValveEntry = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ValveExit = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valves", x => x.ValveID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valves");
        }
    }
}
