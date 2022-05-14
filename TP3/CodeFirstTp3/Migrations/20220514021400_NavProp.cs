using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstTp3.Migrations
{
    public partial class NavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceID",
                table: "participant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConferenceID",
                table: "membreComite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSoumis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    ConferenceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_conference_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "conference",
                        principalColumn: "ConferenceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleParticipant",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleParticipant", x => new { x.ArticlesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_ArticleParticipant_Article_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleParticipant_participant_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_participant_ConferenceID",
                table: "participant",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_membreComite_ConferenceID",
                table: "membreComite",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ConferenceID",
                table: "Article",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleParticipant_ParticipantsId",
                table: "ArticleParticipant",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_membreComite_conference_ConferenceID",
                table: "membreComite",
                column: "ConferenceID",
                principalTable: "conference",
                principalColumn: "ConferenceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_participant_conference_ConferenceID",
                table: "participant",
                column: "ConferenceID",
                principalTable: "conference",
                principalColumn: "ConferenceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_membreComite_conference_ConferenceID",
                table: "membreComite");

            migrationBuilder.DropForeignKey(
                name: "FK_participant_conference_ConferenceID",
                table: "participant");

            migrationBuilder.DropTable(
                name: "ArticleParticipant");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropIndex(
                name: "IX_participant_ConferenceID",
                table: "participant");

            migrationBuilder.DropIndex(
                name: "IX_membreComite_ConferenceID",
                table: "membreComite");

            migrationBuilder.DropColumn(
                name: "ConferenceID",
                table: "participant");

            migrationBuilder.DropColumn(
                name: "ConferenceID",
                table: "membreComite");
        }
    }
}
