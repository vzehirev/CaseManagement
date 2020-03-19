using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedCasePriorities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CasePriorities",
                column: "Priority",
                values: new object[]
                {
                    "Low",
                    "Normal",
                    "Urgent",
                    "Immediate",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CasePriorities",
                keyColumn: "Priority",
                keyValues: new object[]
                {
                    "Low",
                    "Normal",
                    "Urgent",
                    "Immediate",
                });
        }
    }
}
