using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePPMTaskTableDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "PPMTaskHistory",
                newName: "HistoryID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "PPMTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceCompletionDate",
                table: "PPMTasks",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "MaintenanceCompletionDate",
                table: "PPMTasks");

            migrationBuilder.RenameColumn(
                name: "HistoryID",
                table: "PPMTaskHistory",
                newName: "TaskID");
        }
    }
}
