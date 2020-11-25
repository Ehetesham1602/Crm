using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.DataLayer.Migrations
{
    public partial class DbMigration20201610 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_Addresses_AddressId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId",
                table: "Lead");

            migrationBuilder.AlterColumn<int>(
                name: "LeadStatusId",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LeadSourceId",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Lead",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_Addresses_AddressId",
                table: "Lead",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId",
                table: "Lead",
                column: "LeadSourceId",
                principalTable: "LeadSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId",
                table: "Lead",
                column: "LeadStatusId",
                principalTable: "LeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_Addresses_AddressId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadSource_LeadSourceId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_LeadStatus_LeadStatusId",
                table: "Lead");

            migrationBuilder.AlterColumn<int>(
                name: "LeadStatusId",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeadSourceId",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Lead",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_Addresses_AddressId",
                table: "Lead",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
