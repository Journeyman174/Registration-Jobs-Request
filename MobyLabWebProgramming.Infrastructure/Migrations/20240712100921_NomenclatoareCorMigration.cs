using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NomenclatoareCorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cor_CnpCalificari_Id",
                table: "Cor");

            migrationBuilder.AddColumn<Guid>(
                name: "CorId",
                table: "CnpCalificari",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CnpCalificari_CorId",
                table: "CnpCalificari",
                column: "CorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CnpCalificari_Cor_CorId",
                table: "CnpCalificari",
                column: "CorId",
                principalTable: "Cor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CnpCalificari_Cor_CorId",
                table: "CnpCalificari");

            migrationBuilder.DropIndex(
                name: "IX_CnpCalificari_CorId",
                table: "CnpCalificari");

            migrationBuilder.DropColumn(
                name: "CorId",
                table: "CnpCalificari");

            migrationBuilder.AddForeignKey(
                name: "FK_Cor_CnpCalificari_Id",
                table: "Cor",
                column: "Id",
                principalTable: "CnpCalificari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
