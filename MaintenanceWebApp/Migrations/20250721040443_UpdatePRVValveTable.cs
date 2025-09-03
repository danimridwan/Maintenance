using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePRVValveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRVValvePumps");

            migrationBuilder.CreateTable(
                name: "PRVValves",
                columns: table => new
                {
                    PRVValveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DiameterValue = table.Column<double>(type: "float", nullable: true),
                    DiameterUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignPressureValue = table.Column<double>(type: "float", nullable: true),
                    DesignPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRVValves", x => x.PRVValveID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRVValves");

            migrationBuilder.CreateTable(
                name: "PRVValvePumps",
                columns: table => new
                {
                    PRVValvePumpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DesignPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignPressureValue = table.Column<double>(type: "float", nullable: true),
                    DiameterUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiameterValue = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    TankNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRVValvePumps", x => x.PRVValvePumpID);
                });
        }
    }
}
