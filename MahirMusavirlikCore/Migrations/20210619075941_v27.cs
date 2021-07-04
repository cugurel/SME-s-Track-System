using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceOpenClose_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOpenClose",
                table: "ServiceOpenClose");

            migrationBuilder.RenameTable(
                name: "ServiceOpenClose",
                newName: "ServiceOpenCloses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOpenCloses",
                table: "ServiceOpenCloses",
                column: "OpenCloseId");

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceOpenCloses_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                column: "ServiceOpenCloseOpenCloseId",
                principalTable: "ServiceOpenCloses",
                principalColumn: "OpenCloseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceOpenCloses_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOpenCloses",
                table: "ServiceOpenCloses");

            migrationBuilder.RenameTable(
                name: "ServiceOpenCloses",
                newName: "ServiceOpenClose");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOpenClose",
                table: "ServiceOpenClose",
                column: "OpenCloseId");

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceOpenClose_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                column: "ServiceOpenCloseOpenCloseId",
                principalTable: "ServiceOpenClose",
                principalColumn: "OpenCloseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
