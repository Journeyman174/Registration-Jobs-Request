using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RepartitieDosar1Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosar_Solicitanti_Id",
                table: "Dosar");

            migrationBuilder.CreateIndex(
                name: "IX_Dosar_IdSolicitant",
                table: "Dosar",
                column: "IdSolicitant");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosar_Solicitanti_IdSolicitant",
                table: "Dosar",
                column: "IdSolicitant",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosar_Solicitanti_IdSolicitant",
                table: "Dosar");

            migrationBuilder.DropIndex(
                name: "IX_Dosar_IdSolicitant",
                table: "Dosar");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosar_Solicitanti_Id",
                table: "Dosar",
                column: "Id",
                principalTable: "Solicitanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
