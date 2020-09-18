using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.DataLayer.Migrations
{
    public partial class leadchange180902020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId1",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId1",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_LeadSourceId1",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_LeadStatusId1",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "LeadSourceId1",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "LeadStatusId1",
                table: "Lead");

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "QualifyQuestion",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeadStatusId",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeadSourceId",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Lead",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Lead",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Lead",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadSourceId",
                table: "Lead",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadStatusId",
                table: "Lead",
                column: "LeadStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId",
                table: "Lead",
                column: "LeadSourceId",
                principalTable: "LeadSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId",
                table: "Lead",
                column: "LeadStatusId",
                principalTable: "LeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_LeadSourceId",
                table: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Lead_LeadStatusId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "QualifyQuestion");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Lead");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LeadStatusId",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LeadSourceId",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<int>(
                name: "LeadSourceId1",
                table: "Lead",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadStatusId1",
                table: "Lead",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadSourceId1",
                table: "Lead",
                column: "LeadSourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_LeadStatusId1",
                table: "Lead",
                column: "LeadStatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId1",
                table: "Lead",
                column: "LeadSourceId1",
                principalTable: "LeadSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId1",
                table: "Lead",
                column: "LeadStatusId1",
                principalTable: "LeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
