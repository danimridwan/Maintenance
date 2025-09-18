using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddElectricMotorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricMotors",
                columns: table => new
                {
                    ElectricMotorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Power = table.Column<int>(type: "int", nullable: true),
                    PowerUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsulationClass = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProtectionClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bearing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricMotors", x => x.ElectricMotorID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricMotors");
        }
    }
}
