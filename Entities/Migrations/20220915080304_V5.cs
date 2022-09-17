using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribes",
                table: "Subscribes");

            migrationBuilder.RenameTable(
                name: "Subscribes",
                newName: "Subscribers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subscribers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subscribers");

            migrationBuilder.RenameTable(
                name: "Subscribers",
                newName: "Subscribes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribes",
                table: "Subscribes",
                column: "Id");
        }
    }
}
