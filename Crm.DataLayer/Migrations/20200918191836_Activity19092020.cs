using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.DataLayer.Migrations
{
    public partial class Activity19092020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QualifyQuestionAnswers",
                table: "QualifyQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "QualifyQuestionAnswers",
                newName: "QualifyQuestionAnswer");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "QualifyQuestion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QualifyQuestion",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualifyQuestionAnswer",
                table: "QualifyQuestionAnswer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActivityCall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CallSubject = table.Column<string>(nullable: false),
                    CallDescription = table.Column<string>(nullable: false),
                    CallPurpose = table.Column<string>(nullable: false),
                    CallDate = table.Column<DateTime>(nullable: false),
                    CallTime = table.Column<string>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    EntityMasterId = table.Column<int>(nullable: false),
                    DescriptionHtml = table.Column<string>(maxLength: 40, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingSubject = table.Column<string>(nullable: false),
                    MeetingDescription = table.Column<string>(nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    MeetingTime = table.Column<string>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    EntityMasterId = table.Column<int>(nullable: false),
                    DescriptionHtml = table.Column<string>(maxLength: 40, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoteDescription = table.Column<string>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    EntityMasterId = table.Column<int>(nullable: false),
                    DescriptionHtml = table.Column<string>(maxLength: 40, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNotes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCall");

            migrationBuilder.DropTable(
                name: "ActivityMeeting");

            migrationBuilder.DropTable(
                name: "ActivityNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualifyQuestionAnswer",
                table: "QualifyQuestionAnswer");

            migrationBuilder.RenameTable(
                name: "QualifyQuestionAnswer",
                newName: "QualifyQuestionAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "QualifyQuestion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QualifyQuestion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualifyQuestionAnswers",
                table: "QualifyQuestionAnswers",
                column: "Id");
        }
    }
}
