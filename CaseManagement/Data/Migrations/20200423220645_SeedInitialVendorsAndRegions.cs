using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedInitialVendorsAndRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vendors",
                column: "Name",
                values: new object[]
                {
                    "HPE",
                    "Fujitsu",
                });

            var regionsQuery = @"INSERT INTO Regions (Name, UtcOffset, VendorId) VALUES
                            ('EMEA', 2, (SELECT Id FROM Vendors WHERE Name = 'Fujitsu')),
                            ('APJ', 11, (SELECT Id FROM Vendors WHERE Name = 'Fujitsu')),
                            ('AMER', -4, (SELECT Id FROM Vendors WHERE Name = 'Fujitsu'));";

            migrationBuilder.Sql(regionsQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var regionsQuery = @"DELETE FROM Regions WHERE Name = 'EMEA' AND UtcOffset = 2;
                                 DELETE FROM Regions WHERE Name = 'APJ' AND UtcOffset = 11;
                                 DELETE FROM Regions WHERE Name = 'AMER' AND UtcOffset = -4;";

            migrationBuilder.Sql(regionsQuery);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Name",
                keyValues: new object[]
                {
                    "HPE",
                    "Fujitsu",
                });
        }
    }
}
