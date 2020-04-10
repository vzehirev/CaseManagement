using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddMissingNavigationalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskModificationLogRecords_Tasks_CaseTaskId",
                table: "TaskModificationLogRecords");

            migrationBuilder.DropIndex(
                name: "IX_TaskModificationLogRecords_CaseTaskId",
                table: "TaskModificationLogRecords");

            migrationBuilder.DropColumn(
                name: "CaseTaskId",
                table: "TaskModificationLogRecords");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModificationLogRecords_TaskId",
                table: "TaskModificationLogRecords",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModificationLogRecords_Tasks_TaskId",
                table: "TaskModificationLogRecords",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskModificationLogRecords_Tasks_TaskId",
                table: "TaskModificationLogRecords");

            migrationBuilder.DropIndex(
                name: "IX_TaskModificationLogRecords_TaskId",
                table: "TaskModificationLogRecords");

            migrationBuilder.AddColumn<int>(
                name: "CaseTaskId",
                table: "TaskModificationLogRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskModificationLogRecords_CaseTaskId",
                table: "TaskModificationLogRecords",
                column: "CaseTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModificationLogRecords_Tasks_CaseTaskId",
                table: "TaskModificationLogRecords",
                column: "CaseTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
