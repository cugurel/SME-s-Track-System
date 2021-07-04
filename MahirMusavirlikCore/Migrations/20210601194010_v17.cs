using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SituationId",
                table: "Kobis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Situation",
                columns: table => new
                {
                    SituationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situation", x => x.SituationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kobis_SituationId",
                table: "Kobis",
                column: "SituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kobis_Situation_SituationId",
                table: "Kobis",
                column: "SituationId",
                principalTable: "Situation",
                principalColumn: "SituationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kobis_Situation_SituationId",
                table: "Kobis");

            migrationBuilder.DropTable(
                name: "Situation");

            migrationBuilder.DropIndex(
                name: "IX_Kobis_SituationId",
                table: "Kobis");

            migrationBuilder.DropColumn(
                name: "SituationId",
                table: "Kobis");
        }
    }
}
