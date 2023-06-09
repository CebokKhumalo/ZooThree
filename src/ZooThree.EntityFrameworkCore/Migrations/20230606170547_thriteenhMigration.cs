﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooThree.Migrations
{
    public partial class thriteenhMigration : Migration
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
