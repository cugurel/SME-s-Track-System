using Microsoft.EntityFrameworkCore.Migrations;

namespace MahirMusavirlikCore.Migrations
{
    public partial class v25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenCloseId",
                table: "KobiHizmets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceOpenClose",
                columns: table => new
                {
                    OpenCloseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOpenClose", x => x.OpenCloseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KobiHizmets_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                column: "ServiceOpenCloseOpenCloseId");

            migrationBuilder.AddForeignKey(
                name: "FK_KobiHizmets_ServiceOpenClose_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets",
                column: "ServiceOpenCloseOpenCloseId",
                principalTable: "ServiceOpenClose",
                principalColumn: "OpenCloseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KobiHizmets_ServiceOpenClose_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropTable(
                name: "ServiceOpenClose");

            migrationBuilder.DropIndex(
                name: "IX_KobiHizmets_ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropColumn(
                name: "OpenCloseId",
                table: "KobiHizmets");

            migrationBuilder.DropColumn(
                name: "ServiceOpenCloseOpenCloseId",
                table: "KobiHizmets");
        }
    }
}
