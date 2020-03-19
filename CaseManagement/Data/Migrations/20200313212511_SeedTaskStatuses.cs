using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedTaskStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskStatuses",
                column: "Status",
                values: new object[]
                {
                    "WAITING",
                    "READY",
                    "WORKING",
                    "COMPLETED",
                    "FAILED",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Status",
                keyValues: new object[]
                {
                    "WAITING",
                    "READY",
                    "WORKING",
                    "COMPLETED",
                    "FAILED",
                });
        }
    }
}
