using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooThree.Migrations
{
    public partial class fifteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specieses_Enclosures_EnclosureId",
                table: "Specieses");

            migrationBuilder.DropIndex(
                name: "IX_Specieses_EnclosureId",
                table: "Specieses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Specieses_EnclosureId",
                table: "Specieses",
                column: "EnclosureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specieses_Enclosures_EnclosureId",
                table: "Specieses",
                column: "EnclosureId",
                principalTable: "Enclosures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
