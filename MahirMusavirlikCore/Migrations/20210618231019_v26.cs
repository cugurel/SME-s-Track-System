using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnlasmaSekli",
                table: "KobiHizmets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosyaDurumu",
                table: "KobiHizmets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnlasmaSekli",
                table: "KobiHizmets");

            migrationBuilder.DropColumn(
                name: "DosyaDurumu",
                table: "KobiHizmets");
        }
    }
}
