using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Updateemployeetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTasks_Employees_UserID",
                table: "MaintenanceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks");

            migrationBuilder.DropTable(
                name: "Employees");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "AspNetUsers",
            //    type: "nvarchar(13)",
            //    maxLength: 13,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FullName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleCategory",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserPhoto",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTasks_AspNetUsers_UserID",
                table: "MaintenanceTasks",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PPMTasks_AspNetUsers_UserID",
                table: "PPMTasks",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceTasks_AspNetUsers_UserID",
                table: "MaintenanceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PPMTasks_AspNetUsers_UserID",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleCategory",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.UserID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceTasks_Employees_UserID",
                table: "MaintenanceTasks",
                column: "UserID",
                principalTable: "Employees",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PPMTasks_Employees_UserID",
                table: "PPMTasks",
                column: "UserID",
                principalTable: "Employees",
                principalColumn: "UserID");
        }
    }
}
