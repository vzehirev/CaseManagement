using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class ModifySomeCasePropertiesToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePhases_CasePhaseId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePriorities_CasePriorityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseStatuses_CaseStatusId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseTypes_CaseTypeId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_ServiceAreas_ServiceAreaId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Services_ServiceId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceAreaId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaseTypeId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaseStatusId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CasePriorityId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CasePhaseId",
                table: "Cases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePhases_CasePhaseId",
                table: "Cases",
                column: "CasePhaseId",
                principalTable: "CasePhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePriorities_CasePriorityId",
                table: "Cases",
                column: "CasePriorityId",
                principalTable: "CasePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseStatuses_CaseStatusId",
                table: "Cases",
                column: "CaseStatusId",
                principalTable: "CaseStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseTypes_CaseTypeId",
                table: "Cases",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_ServiceAreas_ServiceAreaId",
                table: "Cases",
                column: "ServiceAreaId",
                principalTable: "ServiceAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Services_ServiceId",
                table: "Cases",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePhases_CasePhaseId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePriorities_CasePriorityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseStatuses_CaseStatusId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseTypes_CaseTypeId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_ServiceAreas_ServiceAreaId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Services_ServiceId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceAreaId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseTypeId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseStatusId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CasePriorityId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CasePhaseId",
                table: "Cases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePhases_CasePhaseId",
                table: "Cases",
                column: "CasePhaseId",
                principalTable: "CasePhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePriorities_CasePriorityId",
                table: "Cases",
                column: "CasePriorityId",
                principalTable: "CasePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseStatuses_CaseStatusId",
                table: "Cases",
                column: "CaseStatusId",
                principalTable: "CaseStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseTypes_CaseTypeId",
                table: "Cases",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_ServiceAreas_ServiceAreaId",
                table: "Cases",
                column: "ServiceAreaId",
                principalTable: "ServiceAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Services_ServiceId",
                table: "Cases",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
