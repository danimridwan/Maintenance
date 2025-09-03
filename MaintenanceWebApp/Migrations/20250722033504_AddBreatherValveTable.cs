using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddBreatherValveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreatherValves",
                columns: table => new
                {
                    BreatherValveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tank = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DiameterValue = table.Column<double>(type: "float", nullable: true),
                    DiameterUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignPressurePos = table.Column<double>(type: "float", nullable: true),
                    DesignPressureNeg = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreatherValves", x => x.BreatherValveID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreatherValves");
        }
    }
}
