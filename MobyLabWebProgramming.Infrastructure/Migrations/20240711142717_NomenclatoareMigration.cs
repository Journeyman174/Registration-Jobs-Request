using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NomenclatoareMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Studii",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Repartitie",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Olm",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Cor",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Studii_UserId",
                table: "Studii",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_UserId",
                table: "Repartitie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Olm_UserId",
                table: "Olm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cor_UserId",
                table: "Cor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cor_User_UserId",
                table: "Cor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Olm_User_UserId",
                table: "Olm",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repartitie_User_UserId",
                table: "Repartitie",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studii_User_UserId",
                table: "Studii",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cor_User_UserId",
                table: "Cor");

            migrationBuilder.DropForeignKey(
                name: "FK_Olm_User_UserId",
                table: "Olm");

            migrationBuilder.DropForeignKey(
                name: "FK_Repartitie_User_UserId",
                table: "Repartitie");

            migrationBuilder.DropForeignKey(
                name: "FK_Studii_User_UserId",
                table: "Studii");

            migrationBuilder.DropIndex(
                name: "IX_Studii_UserId",
                table: "Studii");

            migrationBuilder.DropIndex(
                name: "IX_Repartitie_UserId",
                table: "Repartitie");

            migrationBuilder.DropIndex(
                name: "IX_Olm_UserId",
                table: "Olm");

            migrationBuilder.DropIndex(
                name: "IX_Cor_UserId",
                table: "Cor");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Studii");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Repartitie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Olm");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cor");
        }
    }
}
