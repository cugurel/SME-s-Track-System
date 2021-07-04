using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kobis_Situation_SituationId",
                table: "Kobis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Situation",
                table: "Situation");

            migrationBuilder.RenameTable(
                name: "Situation",
                newName: "Situations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Situations",
                table: "Situations",
                column: "SituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kobis_Situations_SituationId",
                table: "Kobis",
                column: "SituationId",
                principalTable: "Situations",
                principalColumn: "SituationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kobis_Situations_SituationId",
                table: "Kobis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Situations",
                table: "Situations");

            migrationBuilder.RenameTable(
                name: "Situations",
                newName: "Situation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Situation",
                table: "Situation",
                column: "SituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kobis_Situation_SituationId",
                table: "Kobis",
                column: "SituationId",
                principalTable: "Situation",
                principalColumn: "SituationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
