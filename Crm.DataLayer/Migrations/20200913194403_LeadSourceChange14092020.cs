using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.DataLayer.Migrations
{
    public partial class LeadSourceChange14092020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LeadSource",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeadSource");
        }
    }
}
