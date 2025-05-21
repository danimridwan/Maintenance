using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InventoryTableInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    TankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    InternalCoating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.TankID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankID = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mmh20Plus = table.Column<int>(type: "int", nullable: true),
                    Mmh20Minus = table.Column<int>(type: "int", nullable: true),
                    BreatherValveDiameter = table.Column<int>(type: "int", nullable: true),
                    FLowMeterTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowMeterTemperatureDesigned = table.Column<int>(type: "int", nullable: true),
                    FlowMeterPressureDesigned = table.Column<int>(type: "int", nullable: true),
                    FlowMeterRate = table.Column<int>(type: "int", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCValveTankDesignedPressure = table.Column<int>(type: "int", nullable: true),
                    PCValveTankDiameter = table.Column<int>(type: "int", nullable: true),
                    PRVValvePumpDesignedPressure = table.Column<int>(type: "int", nullable: true),
                    PRValvePumpDiameter = table.Column<int>(type: "int", nullable: true),
                    PRVValveTankDesignedPressure = table.Column<int>(type: "int", nullable: true),
                    PRValveTankDiameter = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PumpTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PumpCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExplotionProofCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValveDiameter = table.Column<int>(type: "int", nullable: true),
                    Layer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalUnit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Tanks_TankID",
                        column: x => x.TankID,
                        principalTable: "Tanks",
                        principalColumn: "TankID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_TankID",
                table: "Inventories",
                column: "TankID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}
