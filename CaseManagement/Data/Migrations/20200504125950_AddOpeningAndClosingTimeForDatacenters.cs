using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddOpeningAndClosingTimeForDatacenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClosingAtDay",
                table: "Datacenters",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ClosingAtTime",
                table: "Datacenters",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "OpeningAtDay",
                table: "Datacenters",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OpeningAtTime",
                table: "Datacenters",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingAtDay",
                table: "Datacenters");

            migrationBuilder.DropColumn(
                name: "ClosingAtTime",
                table: "Datacenters");

            migrationBuilder.DropColumn(
                name: "OpeningAtDay",
                table: "Datacenters");

            migrationBuilder.DropColumn(
                name: "OpeningAtTime",
                table: "Datacenters");
        }
    }
}
