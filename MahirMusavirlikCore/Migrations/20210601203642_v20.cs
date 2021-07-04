using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kobis_Situations_SituationId",
                table: "Kobis");

            migrationBuilder.DropIndex(
                name: "IX_Kobis_SituationId",
                table: "Kobis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Kobis_SituationId",
                table: "Kobis",
                column: "SituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kobis_Situations_SituationId",
                table: "Kobis",
                column: "SituationId",
                principalTable: "Situations",
                principalColumn: "SituationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
