using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstTemplate.Migrations
{
    public partial class NinjaFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas");

            migrationBuilder.RenameColumn(
                name: "DojoId",
                table: "Ninjas",
                newName: "Dojoid");

            migrationBuilder.RenameIndex(
                name: "IX_Ninjas_DojoId",
                table: "Ninjas",
                newName: "IX_Ninjas_Dojoid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ninjas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dojoid",
                table: "Ninjas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dojos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ninjas_Dojos_Dojoid",
                table: "Ninjas",
                column: "Dojoid",
                principalTable: "Dojos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninjas_Dojos_Dojoid",
                table: "Ninjas");

            migrationBuilder.RenameColumn(
                name: "Dojoid",
                table: "Ninjas",
                newName: "DojoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ninjas_Dojoid",
                table: "Ninjas",
                newName: "IX_Ninjas_DojoId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ninjas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DojoId",
                table: "Ninjas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dojos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas",
                column: "DojoId",
                principalTable: "Dojos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
