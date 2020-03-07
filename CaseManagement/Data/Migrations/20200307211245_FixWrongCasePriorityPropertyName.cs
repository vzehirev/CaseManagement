using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class FixWrongCasePriorityPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CasePriorities");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "CasePriorities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "CasePriorities");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CasePriorities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
