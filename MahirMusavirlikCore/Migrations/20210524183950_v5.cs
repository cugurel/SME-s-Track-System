using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sozlesmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SozlesmeTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SozlesmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnlasmaSekli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KobiId = table.Column<int>(type: "int", nullable: false),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sozlesmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sozlesmes_Kobis_KobiId",
                        column: x => x.KobiId,
                        principalTable: "Kobis",
                        principalColumn: "KobiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sozlesmes_KobiId",
                table: "Sozlesmes",
                column: "KobiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sozlesmes");
        }
    }
}
