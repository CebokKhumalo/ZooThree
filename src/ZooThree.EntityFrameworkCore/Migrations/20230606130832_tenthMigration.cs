using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooThree.Migrations
{
    public partial class tenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specieses_Enclosures_EnclosureId",
                table: "Specieses");

            migrationBuilder.DropIndex(
                name: "IX_Specieses_EnclosureId",
                table: "Specieses");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnclosureId",
                table: "Specieses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EnclosureId",
                table: "Specieses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Specieses_EnclosureId",
                table: "Specieses",
                column: "EnclosureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specieses_Enclosures_EnclosureId",
                table: "Specieses",
                column: "EnclosureId",
                principalTable: "Enclosures",
                principalColumn: "Id");
        }
    }
}
