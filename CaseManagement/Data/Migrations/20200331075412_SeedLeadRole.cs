using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedLeadRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new string[]
                {
                    "Id",
                    "Name",
                    "NormalizedName",
                    "ConcurrencyStamp",
                },
                values: new object[]
                {
                    Guid.NewGuid().ToString(),
                    "Lead",
                    "LEAD",
                    Guid.NewGuid().ToString(),
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new string[]
                {
                    "Name",
                    "NormalizedName",
                },
                keyValues: new object[]
                {
                    "Lead",
                    "LEAD",
                });
        }
    }
}
