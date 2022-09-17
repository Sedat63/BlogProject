using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeaderImage",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ImageId",
                table: "ArticleImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Images_ImageId",
                table: "ArticleImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Images_ImageId",
                table: "ArticleImages");

            migrationBuilder.DropIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages");

            migrationBuilder.DropIndex(
                name: "IX_ArticleImages_ImageId",
                table: "ArticleImages");

            migrationBuilder.DropColumn(
                name: "HeaderImage",
                table: "Articles");
        }
    }
}
