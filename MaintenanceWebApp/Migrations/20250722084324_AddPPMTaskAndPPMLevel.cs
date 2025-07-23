using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPPMTaskAndPPMLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PPMTasks_AspNetUsers_UserID",
                table: "PPMTasks");

            migrationBuilder.DropIndex(
                name: "IX_PPMTasks_UserID",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "CompletePhoto",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "JobDesc",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PPMTasks");

            migrationBuilder.RenameColumn(
                name: "WorkType",
                table: "PPMTasks",
                newName: "PPMID");

            migrationBuilder.RenameColumn(
                name: "SupportingDocument",
                table: "PPMTasks",
                newName: "JobCategory");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PPMTasks",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "RequestorNotes",
                table: "PPMTasks",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "PPMTasks",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "TargetDate",
                table: "PPMTasks",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "TargetCompletion",
                table: "PPMTasks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluationNote",
                table: "PPMTasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAfter",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageBefore",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "PPMTasks",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MTDNote",
                table: "PPMTasks",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceCategory",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenancePIC",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionNote",
                table: "PPMTasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestorNote",
                table: "PPMTasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "EvaluationNote",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "ImageAfter",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "ImageBefore",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "MTDNote",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "MaintenanceCategory",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "MaintenancePIC",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "RejectionNote",
                table: "PPMTasks");

            migrationBuilder.DropColumn(
                name: "RequestorNote",
                table: "PPMTasks");

            migrationBuilder.RenameColumn(
                name: "PPMID",
                table: "PPMTasks",
                newName: "WorkType");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "PPMTasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "JobCategory",
                table: "PPMTasks",
                newName: "SupportingDocument");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "PPMTasks",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "PPMTasks",
                newName: "RequestorNotes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TargetDate",
                table: "PPMTasks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "TargetCompletion",
                table: "PPMTasks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompletePhoto",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Division",
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PPMTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobDesc",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requestor",
                table: "PPMTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "PPMTasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PPMTasks_UserID",
                table: "PPMTasks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PPMTasks_AspNetUsers_UserID",
                table: "PPMTasks",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
