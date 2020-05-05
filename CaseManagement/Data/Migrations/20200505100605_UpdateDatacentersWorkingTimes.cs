using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;

namespace CaseManagement.Data.Migrations
{
    public partial class UpdateDatacentersWorkingTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sydney", "SYD" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(9, 0, 0), 5, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Tokyo", "TOK" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(9, 0, 0), 5, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Osaka", "OSA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(9, 0, 0), 5, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Beijing", "BJN" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Shanghai", "SHA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(9, 0, 0), 5, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Dubai", "DUB" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 0, new TimeSpan(9, 0, 0), 4, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Dammam", "DAM" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 0, new TimeSpan(9, 0, 0), 4, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Riyadh", "RYD" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 0, new TimeSpan(9, 0, 0), 4, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Moscow", "MOS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(9, 0, 0), 5, new TimeSpan(18, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Amsterdam", "AMS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Frankfurt", "FRA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Rot", "ROT" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Walldorf", "WDF" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sao Paulo", "SAO" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Ashburn", "ASH" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Newtown Square", "NSQ" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sterling", "STE" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Toronto", "TOR" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Waltham", "WLH" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Chandler", "CHA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Colorado Springs", "COS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Santa Clara", "SCL" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { 1, new TimeSpan(8, 0, 0), 5, new TimeSpan(17, 0, 0) }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sydney", "SYD" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Tokyo", "TOK" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Osaka", "OSA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Beijing", "BJN" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Shanghai", "SHA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Dubai", "DUB" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Dammam", "DAM" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Riyadh", "RYD" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Moscow", "MOS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Amsterdam", "AMS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Frankfurt", "FRA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Rot", "ROT" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Walldorf", "WDF" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sao Paulo", "SAO" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Ashburn", "ASH" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Newtown Square", "NSQ" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Sterling", "STE" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Toronto", "TOR" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Waltham", "WLH" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Chandler", "CHA" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Colorado Springs", "COS" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );

            migrationBuilder.UpdateData(
                table: "Datacenters",
                keyColumns: new string[] { "Name", "Tag" },
                keyValues: new string[] { "Santa Clara", "SCL" },
                columns: new string[] { "OpeningAtDay", "OpeningAtTime", "ClosingAtDay", "ClosingAtTime" },
                values: new object[] { null, new TimeSpan(0, 0, 0), null, new TimeSpan(0, 0, 0) }
                );
        }
    }
}
