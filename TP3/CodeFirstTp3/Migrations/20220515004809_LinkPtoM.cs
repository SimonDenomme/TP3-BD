using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstTp3.Migrations
{
    public partial class LinkPtoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_conference_ConferenceID",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleParticipant_Article_ArticlesId",
                table: "ArticleParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "article");

            migrationBuilder.RenameIndex(
                name: "IX_Article_ConferenceID",
                table: "article",
                newName: "IX_article_ConferenceID");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "membreComite",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_article",
                table: "article",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_membreComite_ParticipantId",
                table: "membreComite",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_article_conference_ConferenceID",
                table: "article",
                column: "ConferenceID",
                principalTable: "conference",
                principalColumn: "ConferenceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleParticipant_article_ArticlesId",
                table: "ArticleParticipant",
                column: "ArticlesId",
                principalTable: "article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_membreComite_participant_ParticipantId",
                table: "membreComite",
                column: "ParticipantId",
                principalTable: "participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_article_conference_ConferenceID",
                table: "article");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleParticipant_article_ArticlesId",
                table: "ArticleParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_membreComite_participant_ParticipantId",
                table: "membreComite");

            migrationBuilder.DropIndex(
                name: "IX_membreComite_ParticipantId",
                table: "membreComite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_article",
                table: "article");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "membreComite");

            migrationBuilder.RenameTable(
                name: "article",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_article_ConferenceID",
                table: "Article",
                newName: "IX_Article_ConferenceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_conference_ConferenceID",
                table: "Article",
                column: "ConferenceID",
                principalTable: "conference",
                principalColumn: "ConferenceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleParticipant_Article_ArticlesId",
                table: "ArticleParticipant",
                column: "ArticlesId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
