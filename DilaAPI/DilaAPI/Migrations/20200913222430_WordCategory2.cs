using Microsoft.EntityFrameworkCore.Migrations;

namespace DilaAPI.Migrations
{
    public partial class WordCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_category_word_wordid",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "pk_category",
                table: "category");

            migrationBuilder.DropIndex(
                name: "ix_category_wordid",
                table: "category");

            migrationBuilder.DropColumn(
                name: "wordid",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "caterogy");

            migrationBuilder.AddPrimaryKey(
                name: "pk_caterogy",
                table: "caterogy",
                column: "id");

            migrationBuilder.CreateTable(
                name: "wordcategory",
                columns: table => new
                {
                    wordid = table.Column<int>(nullable: false),
                    categoryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wordcategory", x => new { x.wordid, x.categoryid });
                    table.ForeignKey(
                        name: "fk_wordcategory_caterogy_categoryid",
                        column: x => x.categoryid,
                        principalTable: "caterogy",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wordcategory_word_wordid",
                        column: x => x.wordid,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_wordcategory_categoryid",
                table: "wordcategory",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wordcategory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_caterogy",
                table: "caterogy");

            migrationBuilder.RenameTable(
                name: "caterogy",
                newName: "category");

            migrationBuilder.AddColumn<int>(
                name: "wordid",
                table: "category",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_category",
                table: "category",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_category_wordid",
                table: "category",
                column: "wordid");

            migrationBuilder.AddForeignKey(
                name: "fk_category_word_wordid",
                table: "category",
                column: "wordid",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
