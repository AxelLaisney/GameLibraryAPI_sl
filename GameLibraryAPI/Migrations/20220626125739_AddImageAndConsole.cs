using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLibraryAPI.Migrations
{
    public partial class AddImageAndConsole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Console",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Console",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Games");
        }
    }
}
