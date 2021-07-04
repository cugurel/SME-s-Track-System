using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SozlesmeSituationId",
                table: "Sozlesmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SozlesmeSituation",
                columns: table => new
                {
                    SozlesmeSituationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SozlesmeSituationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SozlesmeSituation", x => x.SozlesmeSituationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sozlesmes_SozlesmeSituationId",
                table: "Sozlesmes",
                column: "SozlesmeSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituation_SozlesmeSituationId",
                table: "Sozlesmes",
                column: "SozlesmeSituationId",
                principalTable: "SozlesmeSituation",
                principalColumn: "SozlesmeSituationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sozlesmes_SozlesmeSituation_SozlesmeSituationId",
                table: "Sozlesmes");

            migrationBuilder.DropTable(
                name: "SozlesmeSituation");

            migrationBuilder.DropIndex(
                name: "IX_Sozlesmes_SozlesmeSituationId",
                table: "Sozlesmes");

            migrationBuilder.DropColumn(
                name: "SozlesmeSituationId",
                table: "Sozlesmes");
        }
    }
}
