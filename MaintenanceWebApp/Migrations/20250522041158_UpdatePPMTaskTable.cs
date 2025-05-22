using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePPMTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompletePhoto",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Evaluation",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobDesc",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestorNotes",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TargetCompletion",
                table: "PPMTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TargetDate",
                table: "PPMTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletePhoto",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "JobDesc",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "RequestorNotes",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "TargetCompletion",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "TargetDate",
                table: "PPMTasks");
        }
    }
}
