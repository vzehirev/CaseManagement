using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class RenameTimezoneRegionsTableAndTimezonesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimeZoneRegionId",
                table: "Timezones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimezoneRegions",
                table: "TimezoneRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timezones",
                table: "Timezones");

            migrationBuilder.RenameTable(
                name: "TimezoneRegions",
                newName: "TimeZoneRegions");

            migrationBuilder.RenameTable(
                name: "Timezones",
                newName: "Datacenters");

            migrationBuilder.RenameIndex(
                name: "IX_Timezones_TimeZoneRegionId",
                table: "Datacenters",
                newName: "IX_Datacenters_TimeZoneRegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeZoneRegions",
                table: "TimeZoneRegions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datacenters",
                table: "Datacenters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Datacenters_TimeZoneRegions_TimeZoneRegionId",
                table: "Datacenters",
                column: "TimeZoneRegionId",
                principalTable: "TimeZoneRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datacenters_TimeZoneRegions_TimeZoneRegionId",
                table: "Datacenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeZoneRegions",
                table: "TimeZoneRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Datacenters",
                table: "Datacenters");

            migrationBuilder.RenameTable(
                name: "TimeZoneRegions",
                newName: "TimezoneRegions");

            migrationBuilder.RenameTable(
                name: "Datacenters",
                newName: "Timezones");

            migrationBuilder.RenameIndex(
                name: "IX_Datacenters_TimeZoneRegionId",
                table: "Timezones",
                newName: "IX_Timezones_TimeZoneRegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimezoneRegions",
                table: "TimezoneRegions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timezones",
                table: "Timezones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timezones_TimezoneRegions_TimeZoneRegionId",
                table: "Timezones",
                column: "TimeZoneRegionId",
                principalTable: "TimezoneRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
