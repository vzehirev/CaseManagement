using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class MakeCaseStatusAndPriorityRequried : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePriorities_PriorityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseStatuses_StatusId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Cases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Cases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePriorities_PriorityId",
                table: "Cases",
                column: "PriorityId",
                principalTable: "CasePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseStatuses_StatusId",
                table: "Cases",
                column: "StatusId",
                principalTable: "CaseStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePriorities_PriorityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseStatuses_StatusId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Cases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Cases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePriorities_PriorityId",
                table: "Cases",
                column: "PriorityId",
                principalTable: "CasePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseStatuses_StatusId",
                table: "Cases",
                column: "StatusId",
                principalTable: "CaseStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
