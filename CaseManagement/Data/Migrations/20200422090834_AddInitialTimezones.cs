using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddInitialTimezones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var emeaRegionsQuery = @"INSERT INTO Timezones (Name, Tag, TzIanaName, TimezoneRegionId) VALUES
                            ('Amsterdam', 'AMS', 'Europe/Amsterdam', (SELECT Id FROM TimezoneRegions WHERE Name = 'EMEA')),
                            ('Frankfurt', 'FRA', 'Europe/Berlin', (SELECT Id FROM TimezoneRegions WHERE Name = 'EMEA')),
                            ('Moscow', 'MOS', 'Europe/Moscow', (SELECT Id FROM TimezoneRegions WHERE Name = 'EMEA')),
                            ('Rot', 'ROT', 'Europe/Berlin', (SELECT Id FROM TimezoneRegions WHERE Name = 'EMEA')),
                            ('Walldorf', 'WDF', 'Europe/Berlin', (SELECT Id FROM TimezoneRegions WHERE Name = 'EMEA'));";

            var amerRegionsQuery = @"INSERT INTO Timezones (Name, Tag, TzIanaName, TimezoneRegionId) VALUES
                            ('Ashburn', 'ASH', 'America/New_York', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Chandler', 'CHA', 'America/Phoenix', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Colorado Springs', 'COS', 'America/Denver', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Newtown Square', 'NSQ', 'America/New_York', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Santa Clara', 'SCL', 'America/Los_Angeles', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Sao Paulo', 'SAO', 'America/Sao_Paulo', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Sterling', 'STE', 'America/New_York', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Toronto', 'TOR', 'America/Toronto', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER')),
                            ('Waltham', 'WLH', 'America/New_York', (SELECT Id FROM TimezoneRegions WHERE Name = 'AMER'));";

            var apjRegionsQuery = @"INSERT INTO Timezones (Name, Tag, TzIanaName, TimezoneRegionId) VALUES
                            ('Beijing', 'BJN', 'Asia/Shanghai', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Dammam', 'DAM', 'Asia/Riyadh', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Dubai', 'DUB', 'Asia/Dubai', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Osaka', 'OSA', 'Asia/Tokyo', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Riyadh', 'RYD', 'Asia/Riyadh', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Shanghai', 'SHA', 'Asia/Shanghai', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Singapore', 'SNG', 'Asia/Singapore', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Sydney', 'SYD', 'Australia/Sydney', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ')),
                            ('Tokyo', 'TOK', 'Asia/Tokyo', (SELECT Id FROM TimezoneRegions WHERE Name = 'APJ'));";

            migrationBuilder.Sql(emeaRegionsQuery);
            migrationBuilder.Sql(amerRegionsQuery);
            migrationBuilder.Sql(apjRegionsQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var emeaRegionsQuery = @"DELETE FROM Timezones WHERE Name IN (
                            'Amsterdam',
                            'Frankfurt',
                            'Moscow',
                            'Rot',
                            'Walldorf');";

            var amerRegionsQuery = @"DELETE FROM Timezones WHERE Name IN (
                            'Ashburn',
                            'Chandler',
                            'Colorado Springs',
                            'Newtown Square',
                            'Santa Clara',
                            'Sao Paulo',
                            'Sterling',
                            'Toronto',
                            'Waltham');";

            var apjRegionsQuery = @"DELETE FROM Timezones WHERE Name IN (
                            'Beijing',
                            'Dammam',
                            'Dubai',
                            'Osaka',
                            'Riyadh',
                            'Shanghai',
                            'Singapore',
                            'Sydney',
                            'Tokyo');";

            migrationBuilder.Sql(emeaRegionsQuery);
            migrationBuilder.Sql(amerRegionsQuery);
            migrationBuilder.Sql(apjRegionsQuery);
        }
    }
}
