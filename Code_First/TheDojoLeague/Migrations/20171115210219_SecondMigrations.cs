using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeFirstTemplate.Migrations
{
    public partial class SecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dojos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dojos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dojos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DojoId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ninjas_Dojos_DojoId",
                        column: x => x.DojoId,
                        principalTable: "Dojos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ninjas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DojoId = table.Column<int>(nullable: false),
                    NinjaId = table.Column<int>(nullable: false),
                    PendingNinjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.id);
                    table.ForeignKey(
                        name: "FK_Memberships_Dojos_DojoId",
                        column: x => x.DojoId,
                        principalTable: "Dojos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Ninjas_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Ninjas_PendingNinjaId",
                        column: x => x.PendingNinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dojos_UserId",
                table: "Dojos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_DojoId",
                table: "Memberships",
                column: "DojoId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_NinjaId",
                table: "Memberships",
                column: "NinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_PendingNinjaId",
                table: "Memberships",
                column: "PendingNinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninjas_DojoId",
                table: "Ninjas",
                column: "DojoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninjas_UserId",
                table: "Ninjas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Ninjas");

            migrationBuilder.DropTable(
                name: "Dojos");
        }
    }
}
