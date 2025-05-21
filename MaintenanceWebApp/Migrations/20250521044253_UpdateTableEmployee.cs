using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PresentAddress",
                table: "Employees",
                newName: "JobTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Employees",
                newName: "PresentAddress");

            migrationBuilder.AddColumn<decimal>(
                name: "BasicSalary",
                table: "Employees",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
