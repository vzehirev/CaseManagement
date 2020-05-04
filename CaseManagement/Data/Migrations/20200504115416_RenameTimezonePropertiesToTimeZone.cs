using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class RenameTimezonePropertiesToTimeZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimezoneRegionId",
                table: "Timezones");

            migrationBuilder.RenameColumn(
                name: "TimezoneRegionId",
                table: "Timezones",
                newName: "TimeZoneRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Timezones_TimezoneRegionId",
                table: "Timezones",
                newName: "IX_Timezones_TimeZoneRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimeZoneRegionId",
                table: "Timezones",
                column: "TimeZoneRegionId",
                principalTable: "TimezoneRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimeZoneRegionId",
                table: "Timezones");

            migrationBuilder.RenameColumn(
                name: "TimeZoneRegionId",
                table: "Timezones",
                newName: "TimezoneRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Timezones_TimeZoneRegionId",
                table: "Timezones",
                newName: "IX_Timezones_TimezoneRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimezoneRegionId",
                table: "Timezones",
                column: "TimezoneRegionId",
                principalTable: "TimezoneRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
