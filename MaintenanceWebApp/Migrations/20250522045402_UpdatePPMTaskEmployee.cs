using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePPMTaskEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "PPMTasks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks",
                column: "UserID",
                principalTable: "Employees",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "PPMTasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks",
                column: "UserID",
                principalTable: "Employees",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
