using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationServiceSiturationId",
                table: "KobiHizmets");

            migrationBuilder.DropIndex(
                name: "IX_KobiHizmets_ServiceSituationServiceSiturationId",
                table: "KobiHizmets");

            migrationBuilder.DropColumn(
                name: "ServiceSituationServiceSiturationId",
                table: "KobiHizmets");

            migrationBuilder.RenameColumn(
                name: "OpenCloseId",
                table: "KobiHizmets",
                newName: "ServiceSituationId");

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_ServiceSituationId",
                table: "KobiHizmets",
                column: "ServiceSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationId",
                table: "KobiHizmets",
                column: "ServiceSituationId",
                principalTable: "ServiceSituations",
                principalColumn: "ServiceSiturationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationId",
                table: "KobiHizmets");

            migrationBuilder.DropIndex(
                name: "IX_KobiHizmets_ServiceSituationId",
                table: "KobiHizmets");

            migrationBuilder.RenameColumn(
                name: "ServiceSituationId",
                table: "KobiHizmets",
                newName: "OpenCloseId");

            migrationBuilder.AddColumn<int>(
                name: "ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                column: "ServiceSituationServiceSiturationId");

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceSituations_ServiceSituationServiceSiturationId",
                table: "KobiHizmets",
                column: "ServiceSituationServiceSiturationId",
                principalTable: "ServiceSituations",
                principalColumn: "ServiceSiturationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
