using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestorNotePPMTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestorNote",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestorNote",
                table: "PPMTasks");
        }
    }
}
