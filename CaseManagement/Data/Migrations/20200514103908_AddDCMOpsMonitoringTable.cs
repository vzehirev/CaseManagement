using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddDCMOpsMonitoringTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCMOpsMonitoring",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<double>(nullable: true),
                    ReportedDate = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Qstatus = table.Column<string>(nullable: true),
                    WaitingReason = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    TicketType = table.Column<string>(nullable: true),
                    Queue = table.Column<string>(nullable: true),
                    Assigned = table.Column<string>(nullable: true),
                    Resumeat = table.Column<DateTime>(nullable: true),
                    TTESFlag = table.Column<int>(nullable: true),
                    RTPUFlag = table.Column<int>(nullable: true),
                    Changedby = table.Column<string>(nullable: true),
                    UploadTimeIST = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCMOpsMonitoring", x => x.SNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCMOpsMonitoring");
        }
    }
}
