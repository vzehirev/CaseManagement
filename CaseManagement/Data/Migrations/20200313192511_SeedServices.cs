using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class SeedServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                column: "ServiceName",
                values: new object[]
                {
                    "HW_MAINTENANCE_SUPPORT_CISCO",
                    "HW_MAINTENANCE_SUPPORT_IBM",
                    "DC_GOODS_DELIVERY",
                    "DC_SUPPORT_SERVICES",
                    "DC_NETWORK_SERVICES",
                    "HW_MAINTENANCE_SUPPORT_FUJITSU",
                    "HW_MAINTENANCE_SUPPORT_HP",
                    "HW_MAINTENANCE_SUPPORT_CISCO",
                    "HW_MAINTENANCE_SUPPORT_OTHER",
                    "DC_NETWORK_SERVICES_RH",
                    "CO_LOCATION_DC_ACCESS",
                    "DC_SMARTHANDS_OTHERS",
                    "DC_BUILD_CHANGE",
                    "DC_ASSET_CLEARANCE",
                    "DC_HDD_SHIPMENT",
                    "DC_SUPPORT_SERVICES_RH_ONLY_COLORADO",
                    "DC_ASSET_RELOCATION",
                    "DC_ACCESS_REQUESTS_ADAM_PIT",
                    "DC_ASSET_DECOM",
                    "Other",
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceName",
                keyValues: new object[]
                {
                    "HW_MAINTENANCE_SUPPORT_CISCO",
                    "HW_MAINTENANCE_SUPPORT_IBM",
                    "DC_GOODS_DELIVERY",
                    "DC_SUPPORT_SERVICES",
                    "DC_NETWORK_SERVICES",
                    "HW_MAINTENANCE_SUPPORT_FUJITSU",
                    "HW_MAINTENANCE_SUPPORT_HP",
                    "HW_MAINTENANCE_SUPPORT_CISCO",
                    "HW_MAINTENANCE_SUPPORT_OTHER",
                    "DC_NETWORK_SERVICES_RH",
                    "CO_LOCATION_DC_ACCESS",
                    "DC_SMARTHANDS_OTHERS",
                    "DC_BUILD_CHANGE",
                    "DC_ASSET_CLEARANCE",
                    "DC_HDD_SHIPMENT",
                    "DC_SUPPORT_SERVICES_RH_ONLY_COLORADO",
                    "DC_ASSET_RELOCATION",
                    "DC_ACCESS_REQUESTS_ADAM_PIT",
                    "DC_ASSET_DECOM",
                    "Other",
                });
        }
    }
}
