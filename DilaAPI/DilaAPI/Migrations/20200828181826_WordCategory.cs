using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DilaAPI.Migrations
{
    public partial class WordCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emoji",
                table: "word",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "language",
                table: "word",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "translation",
                table: "word",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "word",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    wordid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                    table.ForeignKey(
                        name: "fk_category_word_wordid",
                        column: x => x.wordid,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_wordid",
                table: "category",
                column: "wordid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropColumn(
                name: "emoji",
                table: "word");

            migrationBuilder.DropColumn(
                name: "language",
                table: "word");

            migrationBuilder.DropColumn(
                name: "translation",
                table: "word");

            migrationBuilder.DropColumn(
                name: "type",
                table: "word");
        }
    }
}
