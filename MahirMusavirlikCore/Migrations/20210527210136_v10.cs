using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SozlesmeTuru",
                table: "AktifDokumans",
                newName: "Detay");

            migrationBuilder.RenameColumn(
                name: "DosyaAdi",
                table: "AktifDokumans",
                newName: "Aciklama");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detay",
                table: "AktifDokumans",
                newName: "SozlesmeTuru");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "AktifDokumans",
                newName: "DosyaAdi");
        }
    }
}
