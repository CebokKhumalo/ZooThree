using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooThree.Migrations
{
    public partial class _18th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeciesId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Births",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Births", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Births_Specieses_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Specieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Births_SpeciesId",
                table: "Births",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals",
                column: "SpeciesId",
                principalTable: "Specieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Births");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpeciesId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Specieses_SpeciesId",
                table: "Animals",
                column: "SpeciesId",
                principalTable: "Specieses",
                principalColumn: "Id");
        }
    }
}
