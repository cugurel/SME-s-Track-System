using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituation_SozlesmeSituationId",
                table: "Sozlesmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SozlesmeSituation",
                table: "SozlesmeSituation");

            migrationBuilder.RenameTable(
                name: "SozlesmeSituation",
                newName: "SozlesmeSituations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SozlesmeSituations",
                table: "SozlesmeSituations",
                column: "SozlesmeSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituations_SozlesmeSituationId",
                table: "Sozlesmes",
                column: "SozlesmeSituationId",
                principalTable: "SozlesmeSituations",
                principalColumn: "SozlesmeSituationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituations_SozlesmeSituationId",
                table: "Sozlesmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SozlesmeSituations",
                table: "SozlesmeSituations");

            migrationBuilder.RenameTable(
                name: "SozlesmeSituations",
                newName: "SozlesmeSituation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SozlesmeSituation",
                table: "SozlesmeSituation",
                column: "SozlesmeSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituation_SozlesmeSituationId",
                table: "Sozlesmes",
                column: "SozlesmeSituationId",
                principalTable: "SozlesmeSituation",
                principalColumn: "SozlesmeSituationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
