using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedCasePhases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CasePhases",
                column: "Phase",
                values: new object[]
                {
                    "Evaluate",
                    "Plan & Prepare",
                    "Execute",
                    "Post steps",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CasePhases",
                keyColumn: "Phase",
                keyValues: new object[]
                {
                    "Evaluate",
                    "Plan & Prepare",
                    "Execute",
                    "Post steps",
                });
        }
    }
}
