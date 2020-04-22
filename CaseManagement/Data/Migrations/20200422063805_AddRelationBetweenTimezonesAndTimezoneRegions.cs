using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddRelationBetweenTimezonesAndTimezoneRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimezoneRegionId",
                table: "Timezones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Timezones_TimezoneRegionId",
                table: "Timezones",
                column: "TimezoneRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimezoneRegionId",
                table: "Timezones",
                column: "TimezoneRegionId",
                principalTable: "TimezoneRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimezoneRegionId",
                table: "Timezones");

            migrationBuilder.DropIndex(
                name: "IX_Timezones_TimezoneRegionId",
                table: "Timezones");

            migrationBuilder.DropColumn(
                name: "TimezoneRegionId",
                table: "Timezones");
        }
    }
}
