using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Nomenclatoare2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studii_CnpStudii_Id",
                table: "Studii");

            migrationBuilder.AddColumn<Guid>(
                name: "IdStudii",
                table: "Studii",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Studii_IdStudii",
                table: "Studii",
                column: "IdStudii",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Studii_CnpStudii_IdStudii",
                table: "Studii",
                column: "IdStudii",
                principalTable: "CnpStudii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studii_CnpStudii_IdStudii",
                table: "Studii");

            migrationBuilder.DropIndex(
                name: "IX_Studii_IdStudii",
                table: "Studii");

            migrationBuilder.DropColumn(
                name: "IdStudii",
                table: "Studii");

            migrationBuilder.AddForeignKey(
                name: "FK_Studii_CnpStudii_Id",
                table: "Studii",
                column: "Id",
                principalTable: "CnpStudii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
