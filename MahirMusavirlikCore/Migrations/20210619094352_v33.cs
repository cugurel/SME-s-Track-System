using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceOpenCloses_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropTable(
                name: "ServiceOpenCloses");

            migrationBuilder.RenameColumn(
                name: "ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                newName: "ServiceSituationServiceSiturationId");

            migrationBuilder.RenameIndex(
                name: "IX_KobiHizmets_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                newName: "IX_KobiHizmets_ServiceSituationServiceSiturationId");

            migrationBuilder.CreateTable(
                name: "ServiceSituations",
                columns: table => new
                {
                    ServiceSiturationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSituations", x => x.ServiceSiturationId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                column: "ServiceSituationServiceSiturationId",
                principalTable: "ServiceSituations",
                principalColumn: "ServiceSiturationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationServiceSiturationId",
                table: "KobiHizmets");

            migrationBuilder.DropTable(
                name: "ServiceSituations");

            migrationBuilder.RenameColumn(
                name: "ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                newName: "ServiceOpenCloseOpenCloseId");

            migrationBuilder.RenameIndex(
                name: "IX_KobiHizmets_ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                newName: "IX_KobiHizmets_ServiceOpenCloseOpenCloseId");

            migrationBuilder.CreateTable(
                name: "ServiceOpenCloses",
                columns: table => new
                {
                    OpenCloseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOpenCloses", x => x.OpenCloseId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceOpenCloses_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                column: "ServiceOpenCloseOpenCloseId",
                principalTable: "ServiceOpenCloses",
                principalColumn: "OpenCloseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
