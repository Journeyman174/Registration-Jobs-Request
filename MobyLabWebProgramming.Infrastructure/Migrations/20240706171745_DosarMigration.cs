using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DosarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NrDosar",
                table: "Dosar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Dosar",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Dosar_NrDosar",
                table: "Dosar",
                column: "NrDosar");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitanti_UserId",
                table: "Solicitanti",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosar_UserId",
                table: "Dosar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosar_User_UserId",
                table: "Dosar",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitanti_User_UserId",
                table: "Solicitanti",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosar_User_UserId",
                table: "Dosar");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitanti_User_UserId",
                table: "Solicitanti");

            migrationBuilder.DropIndex(
                name: "IX_Solicitanti_UserId",
                table: "Solicitanti");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Dosar_NrDosar",
                table: "Dosar");

            migrationBuilder.DropIndex(
                name: "IX_Dosar_UserId",
                table: "Dosar");

            migrationBuilder.DropColumn(
                name: "NrDosar",
                table: "Dosar");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dosar");
        }
    }
}
