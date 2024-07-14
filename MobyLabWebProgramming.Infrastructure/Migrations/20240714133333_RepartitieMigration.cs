using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RepartitieMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repartitie_DosarRepartitii_DosarRepartitiiId",
                table: "Repartitie");

            migrationBuilder.DropForeignKey(
                name: "FK_Repartitie_Dosar_DosarRId",
                table: "Repartitie");

            migrationBuilder.DropIndex(
                name: "IX_Repartitie_DosarRepartitiiId",
                table: "Repartitie");

            migrationBuilder.DropIndex(
                name: "IX_Repartitie_DosarRId",
                table: "Repartitie");

            migrationBuilder.DropColumn(
                name: "DosarRId",
                table: "Repartitie");

            migrationBuilder.DropColumn(
                name: "DosarRepartitiiId",
                table: "Repartitie");

            migrationBuilder.AddColumn<Guid>(
                name: "RepartitieId",
                table: "DosarRepartitii",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DosarRepartitii_RepartitieId",
                table: "DosarRepartitii",
                column: "RepartitieId");

            migrationBuilder.AddForeignKey(
                name: "FK_DosarRepartitii_Repartitie_RepartitieId",
                table: "DosarRepartitii",
                column: "RepartitieId",
                principalTable: "Repartitie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DosarRepartitii_Repartitie_RepartitieId",
                table: "DosarRepartitii");

            migrationBuilder.DropIndex(
                name: "IX_DosarRepartitii_RepartitieId",
                table: "DosarRepartitii");

            migrationBuilder.DropColumn(
                name: "RepartitieId",
                table: "DosarRepartitii");

            migrationBuilder.AddColumn<Guid>(
                name: "DosarRId",
                table: "Repartitie",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DosarRepartitiiId",
                table: "Repartitie",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_DosarRepartitiiId",
                table: "Repartitie",
                column: "DosarRepartitiiId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_DosarRId",
                table: "Repartitie",
                column: "DosarRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repartitie_DosarRepartitii_DosarRepartitiiId",
                table: "Repartitie",
                column: "DosarRepartitiiId",
                principalTable: "DosarRepartitii",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repartitie_Dosar_DosarRId",
                table: "Repartitie",
                column: "DosarRId",
                principalTable: "Dosar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
