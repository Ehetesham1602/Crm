using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.DataLayer.Migrations
{
    public partial class DbMigration20201208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskSubject = table.Column<string>(nullable: false),
                    TaskDescription = table.Column<string>(nullable: false),
                    TaskPurpose = table.Column<string>(nullable: false),
                    TaskDate = table.Column<DateTime>(nullable: false),
                    TaskTime = table.Column<string>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    EntityMasterId = table.Column<int>(nullable: false),
                    DescriptionHtml = table.Column<string>(maxLength: 40, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTask", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTask");
        }
    }
}
