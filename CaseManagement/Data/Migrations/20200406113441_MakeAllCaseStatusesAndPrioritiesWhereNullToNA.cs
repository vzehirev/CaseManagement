using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class MakeAllCaseStatusesAndPrioritiesWhereNullToNA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cases SET StatusId = (SELECT TOP 1 Id FROM CaseStatuses WHERE Status = 'N/A') WHERE StatusId IS NULL;");

            migrationBuilder.Sql("UPDATE Cases SET PriorityId = (SELECT TOP 1 Id FROM CasePriorities WHERE Priority = 'N/A') WHERE PriorityId IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cases SET StatusId = NULL WHERE StatusId = (SELECT TOP 1 Id FROM CaseStatuses WHERE Status = 'N/A');");

            migrationBuilder.Sql("UPDATE Cases SET PriorityId = NULL WHERE PriorityId = (SELECT TOP 1 Id FROM CasePriorities WHERE Priority = 'N/A');");
        }
    }
}
