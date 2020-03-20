using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CaseManagement.Data.Migrations
{
    public partial class AddCaseAndTaskModificationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldModifications_ModificationLogRecords_ModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropTable(
                name: "ModificationLogRecords");

            migrationBuilder.DropIndex(
                name: "IX_FieldModifications_ModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropColumn(
                name: "ModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.AddColumn<int>(
                name: "CaseModificationLogRecordId",
                table: "FieldModifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskModificationLogRecordId",
                table: "FieldModifications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaseModificationLogRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    CaseId = table.Column<int>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseModificationLogRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseModificationLogRecords_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseModificationLogRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskModificationLogRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModificationLogRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskModificationLogRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldModifications_CaseModificationLogRecordId",
                table: "FieldModifications",
                column: "CaseModificationLogRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldModifications_TaskModificationLogRecordId",
                table: "FieldModifications",
                column: "TaskModificationLogRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseModificationLogRecords_CaseId",
                table: "CaseModificationLogRecords",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseModificationLogRecords_UserId",
                table: "CaseModificationLogRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModificationLogRecords_UserId",
                table: "TaskModificationLogRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldModifications_CaseModificationLogRecords_CaseModificationLogRecordId",
                table: "FieldModifications",
                column: "CaseModificationLogRecordId",
                principalTable: "CaseModificationLogRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldModifications_TaskModificationLogRecords_TaskModificationLogRecordId",
                table: "FieldModifications",
                column: "TaskModificationLogRecordId",
                principalTable: "TaskModificationLogRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldModifications_CaseModificationLogRecords_CaseModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldModifications_TaskModificationLogRecords_TaskModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropTable(
                name: "CaseModificationLogRecords");

            migrationBuilder.DropTable(
                name: "TaskModificationLogRecords");

            migrationBuilder.DropIndex(
                name: "IX_FieldModifications_CaseModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropIndex(
                name: "IX_FieldModifications_TaskModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropColumn(
                name: "CaseModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.DropColumn(
                name: "TaskModificationLogRecordId",
                table: "FieldModifications");

            migrationBuilder.AddColumn<int>(
                name: "ModificationLogRecordId",
                table: "FieldModifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModificationLogRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModificationLogRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModificationLogRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldModifications_ModificationLogRecordId",
                table: "FieldModifications",
                column: "ModificationLogRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ModificationLogRecords_UserId",
                table: "ModificationLogRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldModifications_ModificationLogRecords_ModificationLogRecordId",
                table: "FieldModifications",
                column: "ModificationLogRecordId",
                principalTable: "ModificationLogRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
