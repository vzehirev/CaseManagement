using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedCaseTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CaseTypes",
                column: "Type",
                values: new object[]
                {
                    "DCM Regional Tickets",
                    "Server Maintenance Break and Fix (B+F) ",
                    "Time Critical Requests (Incident)",
                    "Time Critical Requests (Requests)",
                    "Requesting DC access",
                    "Requesting Goods Delivery to DCs",
                    "Requesting the announcement of System News",
                    "Requesting different kinds of onsite support activities",
                    "Other",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaseTypes",
                keyColumn: "Type",
                keyValues: new object[]
                {
                    "DCM Regional Tickets",
                    "Server Maintenance Break and Fix (B+F) ",
                    "Time Critical Requests (Incident)",
                    "Time Critical Requests (Requests)",
                    "Requesting DC access",
                    "Requesting Goods Delivery to DCs",
                    "Requesting the announcement of System News",
                    "Requesting different kinds of onsite support activities",
                    "Other",
                });
        }
    }
}
