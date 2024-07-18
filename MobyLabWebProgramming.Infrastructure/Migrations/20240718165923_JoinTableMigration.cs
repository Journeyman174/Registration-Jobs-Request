using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JoinTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DosarRepartitii_Repartitie_IdDosar",
                table: "DosarRepartitii");

            migrationBuilder.CreateIndex(
                name: "IX_DosarRepartitii_IdRepartitie",
                table: "DosarRepartitii",
                column: "IdRepartitie");

            migrationBuilder.AddForeignKey(
                name: "FK_DosarRepartitii_Repartitie_IdRepartitie",
                table: "DosarRepartitii",
                column: "IdRepartitie",
                principalTable: "Repartitie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DosarRepartitii_Repartitie_IdRepartitie",
                table: "DosarRepartitii");

            migrationBuilder.DropIndex(
                name: "IX_DosarRepartitii_IdRepartitie",
                table: "DosarRepartitii");

            migrationBuilder.AddForeignKey(
                name: "FK_DosarRepartitii_Repartitie_IdDosar",
                table: "DosarRepartitii",
                column: "IdDosar",
                principalTable: "Repartitie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
