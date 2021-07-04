using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnlasmaSekli",
                table: "Dosyas");

            migrationBuilder.DropColumn(
                name: "DosyaDurumu",
                table: "Dosyas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnlasmaSekli",
                table: "Dosyas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosyaDurumu",
                table: "Dosyas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
