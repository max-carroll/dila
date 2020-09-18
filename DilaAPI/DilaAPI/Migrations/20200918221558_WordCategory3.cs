using Microsoft.EntityFrameworkCore.Migrations;

namespace DilaAPI.Migrations
{
    public partial class WordCategory3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_wordcategory_caterogy_categoryid",
                table: "wordcategory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_caterogy",
                table: "caterogy");

            migrationBuilder.RenameTable(
                name: "caterogy",
                newName: "category");

            migrationBuilder.AddPrimaryKey(
                name: "pk_category",
                table: "category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_wordcategory_category_categoryid",
                table: "wordcategory",
                column: "categoryid",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_wordcategory_category_categoryid",
                table: "wordcategory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "caterogy");

            migrationBuilder.AddPrimaryKey(
                name: "pk_caterogy",
                table: "caterogy",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_wordcategory_caterogy_categoryid",
                table: "wordcategory",
                column: "categoryid",
                principalTable: "caterogy",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
