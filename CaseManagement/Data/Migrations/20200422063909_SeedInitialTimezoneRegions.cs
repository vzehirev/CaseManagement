using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedInitialTimezoneRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimezoneRegions",
                column: "Name",
                values: new object[]
                {
                    "EMEA",
                    "AMER",
                    "APJ",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimezoneRegions",
                keyColumn: "Name",
                keyValues: new object[]
                {
                    "EMEA",
                    "AMER",
                    "APJ",
                });
        }
    }
}
