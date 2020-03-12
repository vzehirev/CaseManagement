using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddTaskModificationsNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaseTaskId",
                table: "TaskModificationLogRecords",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
