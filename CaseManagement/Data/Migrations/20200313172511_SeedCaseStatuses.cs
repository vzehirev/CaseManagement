using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedCaseStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CaseStatuses",
                column: "Status",
                values: new object[]
                {
                    "New",
                    "Waiting",
                    "In Process",
                    "Resolved",
                    "On-hold",
                    "Closed",
                    "Other",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaseStatuses",
                keyColumn: "Status",
                keyValues: new object[]
                {
                    "New",
                    "Waiting",
                    "In Process",
                    "Resolved",
                    "On-hold",
                    "Closed",
                    "Other",
                });
        }
    }
}
