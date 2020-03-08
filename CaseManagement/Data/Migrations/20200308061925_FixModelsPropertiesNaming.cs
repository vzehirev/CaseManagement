using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagement.Data.Migrations
{
    public partial class FixModelsPropertiesNaming : Migration
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
                name: "FK_Tasks_TaskStatuses_TaskStatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CasePhaseId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CasePriorityId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CaseStatusId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CaseTypeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseEndTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAction",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CaseDescription",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseEndTime",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseNum",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CasePhaseId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CasePriorityId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseStatusId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseSubject",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Tasks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Cases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Cases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Cases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PhaseId",
                table: "Cases",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PriorityId",
                table: "Cases",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_StatusId",
                table: "Cases",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TypeId",
                table: "Cases",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CasePhases_PhaseId",
                table: "Cases",
                column: "PhaseId",
                principalTable: "CasePhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseTypes_TypeId",
                table: "Cases",
                column: "TypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TypeId",
                table: "Tasks",
                column: "TypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePhases_PhaseId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CasePriorities_PriorityId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseStatuses_StatusId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CaseTypes_TypeId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Cases_PhaseId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_PriorityId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_StatusId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_TypeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Cases");

            migrationBuilder.AddColumn<DateTime>(
                name: "CaseEndTime",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TaskAction",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseDescription",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CaseEndTime",
                table: "Cases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseNum",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CasePhaseId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CasePriorityId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseStatusId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseSubject",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CaseTypeId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Cases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CasePhaseId",
                table: "Cases",
                column: "CasePhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CasePriorityId",
                table: "Cases",
                column: "CasePriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseStatusId",
                table: "Cases",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseTypeId",
                table: "Cases",
                column: "CaseTypeId");

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
                name: "FK_Tasks_TaskStatuses_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
