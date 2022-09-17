using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "SocialMedia");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMedia",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedia",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SocialMedia");

            migrationBuilder.RenameTable(
                name: "SocialMedia",
                newName: "SocialMedias");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "Id");
        }
    }
}
