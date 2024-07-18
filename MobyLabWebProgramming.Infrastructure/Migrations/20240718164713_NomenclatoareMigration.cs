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
            migrationBuilder.DropForeignKey(
                name: "FK_CnpCalificari_Solicitanti_IdCor",
                table: "CnpCalificari");

            migrationBuilder.DropForeignKey(
                name: "FK_CnpStudii_Solicitanti_IdStudii",
                table: "CnpStudii");

            migrationBuilder.DropForeignKey(
                name: "FK_CnpStudii_Studii_IdSolicitant",
                table: "CnpStudii");

            migrationBuilder.CreateIndex(
                name: "IX_CnpCalificari_IdSolicitant",
                table: "CnpCalificari",
                column: "IdSolicitant");

            migrationBuilder.AddForeignKey(
                name: "FK_CnpCalificari_Solicitanti_IdSolicitant",
                table: "CnpCalificari",
                column: "IdSolicitant",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CnpStudii_Solicitanti_IdSolicitant",
                table: "CnpStudii",
                column: "IdSolicitant",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CnpStudii_Studii_IdStudii",
                table: "CnpStudii",
                column: "IdStudii",
                principalTable: "Studii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CnpCalificari_Solicitanti_IdSolicitant",
                table: "CnpCalificari");

            migrationBuilder.DropForeignKey(
                name: "FK_CnpStudii_Solicitanti_IdSolicitant",
                table: "CnpStudii");

            migrationBuilder.DropForeignKey(
                name: "FK_CnpStudii_Studii_IdStudii",
                table: "CnpStudii");

            migrationBuilder.DropIndex(
                name: "IX_CnpCalificari_IdSolicitant",
                table: "CnpCalificari");

            migrationBuilder.AddForeignKey(
                name: "FK_CnpCalificari_Solicitanti_IdCor",
                table: "CnpCalificari",
                column: "IdCor",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CnpStudii_Solicitanti_IdStudii",
                table: "CnpStudii",
                column: "IdStudii",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CnpStudii_Studii_IdSolicitant",
                table: "CnpStudii",
                column: "IdSolicitant",
                principalTable: "Studii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
