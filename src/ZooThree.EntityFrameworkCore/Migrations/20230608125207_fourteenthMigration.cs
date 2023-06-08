using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooThree.Migrations
{
    public partial class fourteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "EnclosureName",
                table: "Specieses",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specieses_Enclosures_EnclosureId",
                table: "Specieses");

            migrationBuilder.DropIndex(
                name: "IX_Specieses_EnclosureId",
                table: "Specieses");

            migrationBuilder.DropColumn(
                name: "EnclosureName",
                table: "Specieses");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals",
                column: "SpeciesId",
                principalTable: "Specieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
