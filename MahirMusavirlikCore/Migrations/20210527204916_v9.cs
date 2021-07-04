using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DosyaTarihi",
                table: "HizmetDetayDokumans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AktifDokumans",
                columns: table => new
                {
                    AktifDokumanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SozlesmeTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GecerlilikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KobiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktifDokumans", x => x.AktifDokumanId);
                    table.ForeignKey(
                        name: "FK_AktifDokumans_Kobis_KobiId",
                        column: x => x.KobiId,
                        principalTable: "Kobis",
                        principalColumn: "KobiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktifDokumans_KobiId",
                table: "AktifDokumans",
                column: "KobiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktifDokumans");

            migrationBuilder.DropColumn(
                name: "DosyaTarihi",
                table: "HizmetDetayDokumans");
        }
    }
}
