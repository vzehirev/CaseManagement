using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedTaskTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskTypes",
                column: "Type",
                values: new object[]
                {
                    "Dispatching DCM Regional tickets",
                    "Fetch the logs",
                    "Create Vendor Case",
                    "Shipment Request",
                    "Access Request",
                    "Onsite Support Activities",
                    "DC Escort Request",
                    "Other",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Type",
                keyValues: new object[]
                {
                    "Dispatching DCM Regional tickets",
                    "Fetch the logs",
                    "Create Vendor Case",
                    "Shipment Request",
                    "Access Request",
                    "Onsite Support Activities",
                    "DC Escort Request",
                    "Other",
                });
        }
    }
}
