using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class AddModificationLogRecordsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModificationLogRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FieldModifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(nullable: false),
                    OldValue = table.Column<string>(nullable: false),
                    NewValue = table.Column<string>(nullable: false),
                    ModificationLogRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldModifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldModifications_ModificationLogRecords_ModificationLogRecordId",
                        column: x => x.ModificationLogRecordId,
                        principalTable: "ModificationLogRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldModifications_ModificationLogRecordId",
                table: "FieldModifications",
                column: "ModificationLogRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ModificationLogRecords_UserId",
                table: "ModificationLogRecords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldModifications");

            migrationBuilder.DropTable(
                name: "ModificationLogRecords");
        }
    }
}
