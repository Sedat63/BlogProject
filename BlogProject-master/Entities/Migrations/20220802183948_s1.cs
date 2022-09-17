using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class s1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celal",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UsersId",
                table: "Articles",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UsersId",
                table: "Articles",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UsersId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UsersId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Contents",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Celal",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
