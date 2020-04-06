using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedNACaseStatusAndPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CaseStatuses",
                column: "Status",
                value: "N/A");

            migrationBuilder.InsertData(
                table: "CasePriorities",
                column: "Priority",
                value: "N/A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaseStatuses",
                keyColumn: "Status",
                keyValue: "N/A");

            migrationBuilder.DeleteData(
                table: "CasePriorities",
                keyColumn: "Priority",
                keyValue: "N/A");
        }
    }
}
