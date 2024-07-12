using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Nomenclatoare4Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studii_CnpStudii_Id",
                table: "Studii");

            migrationBuilder.AddColumn<Guid>(
                name: "StudiiId",
                table: "CnpStudii",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CnpStudii_StudiiId",
                table: "CnpStudii",
                column: "StudiiId");

            migrationBuilder.AddForeignKey(
                name: "FK_CnpStudii_Studii_StudiiId",
                table: "CnpStudii",
                column: "StudiiId",
                principalTable: "Studii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CnpStudii_Studii_StudiiId",
                table: "CnpStudii");

            migrationBuilder.DropIndex(
                name: "IX_CnpStudii_StudiiId",
                table: "CnpStudii");

            migrationBuilder.DropColumn(
                name: "StudiiId",
                table: "CnpStudii");

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
