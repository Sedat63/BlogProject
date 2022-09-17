using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Comments_CommentId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_CommentId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "ArticleCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "ArticleCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CommentId",
                table: "ArticleCategories",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Comments_CommentId",
                table: "ArticleCategories",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
