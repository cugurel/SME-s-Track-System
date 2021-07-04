using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AltHizmets",
                columns: table => new
                {
                    AltHizmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltHizmetAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltHizmets", x => x.AltHizmetId);
                });

            migrationBuilder.CreateTable(
                name: "AnaHizmets",
                columns: table => new
                {
                    AnaHizmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaHizmetAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaHizmets", x => x.AnaHizmetId);
                });

            migrationBuilder.CreateTable(
                name: "Kobis",
                columns: table => new
                {
                    KobiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KobiKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiUnvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiVergiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiVergiDaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiYetkili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiTcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiEDevletSifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiEİmzaSifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiReferans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiMaliMusaviri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kobis", x => x.KobiId);
                });

            migrationBuilder.CreateTable(
                name: "KobiHizmets",
                columns: table => new
                {
                    KobiHizmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaHizmetId = table.Column<int>(type: "int", nullable: false),
                    AltHizmetId = table.Column<int>(type: "int", nullable: false),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KobiHizmets", x => x.KobiHizmetId);
                    table.ForeignKey(
                        name: "FK_KobiHizmets_AltHizmets_AltHizmetId",
                        column: x => x.AltHizmetId,
                        principalTable: "AltHizmets",
                        principalColumn: "AltHizmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KobiHizmets_AnaHizmets_AnaHizmetId",
                        column: x => x.AnaHizmetId,
                        principalTable: "AnaHizmets",
                        principalColumn: "AnaHizmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KobiHizmets_Kobis_KobiId",
                        column: x => x.KobiId,
                        principalTable: "Kobis",
                        principalColumn: "KobiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dosyas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaDurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnlasmaSekli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiHizmetId = table.Column<int>(type: "int", nullable: false),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosyas_KobiHizmets_KobiHizmetId",
                        column: x => x.KobiHizmetId,
                        principalTable: "KobiHizmets",
                        principalColumn: "KobiHizmetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosyas_KobiHizmetId",
                table: "Dosyas",
                column: "KobiHizmetId");

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_AltHizmetId",
                table: "KobiHizmets",
                column: "AltHizmetId");

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_AnaHizmetId",
                table: "KobiHizmets",
                column: "AnaHizmetId");

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_KobiId",
                table: "KobiHizmets",
                column: "KobiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dosyas");

            migrationBuilder.DropTable(
                name: "KobiHizmets");

            migrationBuilder.DropTable(
                name: "AltHizmets");

            migrationBuilder.DropTable(
                name: "AnaHizmets");

            migrationBuilder.DropTable(
                name: "Kobis");
        }
    }
}
