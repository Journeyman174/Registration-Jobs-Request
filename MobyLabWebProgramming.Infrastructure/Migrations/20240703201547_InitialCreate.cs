﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,");

            migrationBuilder.CreateTable(
                name: "Solicitanti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInregistare = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CnpSolicitant = table.Column<string>(type: "text", nullable: false),
                    Nume = table.Column<string>(type: "text", nullable: false),
                    Prenume = table.Column<string>(type: "text", nullable: false),
                    Adresa = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitanti", x => x.Id);
                    table.UniqueConstraint("AK_Solicitanti_CnpSolicitant", x => x.CnpSolicitant);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "CnpCalificari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSolicitant = table.Column<Guid>(type: "uuid", nullable: false),
                    CnpSolicitant = table.Column<string>(type: "text", nullable: false),
                    IdCor = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnpCalificari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CnpCalificari_Solicitanti_IdCor",
                        column: x => x.IdCor,
                        principalTable: "Solicitanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CnpStudii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSolicitant = table.Column<Guid>(type: "uuid", nullable: false),
                    CnpSolicitant = table.Column<string>(type: "text", nullable: false),
                    IdStudii = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnpStudii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CnpStudii_Solicitanti_IdStudii",
                        column: x => x.IdStudii,
                        principalTable: "Solicitanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dosar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSolicitant = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDosar = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CnpSolicitant = table.Column<string>(type: "text", nullable: false),
                    DeLa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PanaLa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Stare = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosar_Solicitanti_Id",
                        column: x => x.Id,
                        principalTable: "Solicitanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(4095)", maxLength: 4095, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodCor = table.Column<string>(type: "text", nullable: false),
                    Meserie = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cor_CnpCalificari_Id",
                        column: x => x.Id,
                        principalTable: "CnpCalificari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DenStudii = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studii_CnpStudii_Id",
                        column: x => x.Id,
                        principalTable: "CnpStudii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DosarRepartitii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDosar = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRepartitie = table.Column<Guid>(type: "uuid", nullable: false),
                    DosarId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosarRepartitii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DosarRepartitii_Dosar_DosarId",
                        column: x => x.DosarId,
                        principalTable: "Dosar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Olm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataOlm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataOlmStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataOlmSfarsit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Agent = table.Column<string>(type: "text", nullable: false),
                    CuiFirma = table.Column<string>(type: "text", nullable: false),
                    IdCor = table.Column<Guid>(type: "uuid", nullable: false),
                    AdresaLocMunca = table.Column<string>(type: "text", nullable: false),
                    NrLocMunca = table.Column<int>(type: "integer", nullable: false),
                    Stare = table.Column<string>(type: "text", nullable: false),
                    CorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olm_Cor_CorId",
                        column: x => x.CorId,
                        principalTable: "Cor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repartitie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNP = table.Column<string>(type: "text", nullable: true),
                    DataRepartitie = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdOlm = table.Column<Guid>(type: "uuid", nullable: false),
                    Rezultat = table.Column<string>(type: "text", nullable: false),
                    IdDosar = table.Column<Guid>(type: "uuid", nullable: false),
                    DosarRId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepartitiiOlmId = table.Column<Guid>(type: "uuid", nullable: false),
                    DosarRepartitiiId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartitie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartitie_DosarRepartitii_DosarRepartitiiId",
                        column: x => x.DosarRepartitiiId,
                        principalTable: "DosarRepartitii",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repartitie_Dosar_DosarRId",
                        column: x => x.DosarRId,
                        principalTable: "Dosar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repartitie_Olm_RepartitiiOlmId",
                        column: x => x.RepartitiiOlmId,
                        principalTable: "Olm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CnpCalificari_IdCor",
                table: "CnpCalificari",
                column: "IdCor");

            migrationBuilder.CreateIndex(
                name: "IX_CnpStudii_IdStudii",
                table: "CnpStudii",
                column: "IdStudii");

            migrationBuilder.CreateIndex(
                name: "IX_DosarRepartitii_DosarId",
                table: "DosarRepartitii",
                column: "DosarId");

            migrationBuilder.CreateIndex(
                name: "IX_Olm_CorId",
                table: "Olm",
                column: "CorId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_DosarRepartitiiId",
                table: "Repartitie",
                column: "DosarRepartitiiId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_DosarRId",
                table: "Repartitie",
                column: "DosarRId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartitie_RepartitiiOlmId",
                table: "Repartitie",
                column: "RepartitiiOlmId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFile_UserId",
                table: "UserFile",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repartitie");

            migrationBuilder.DropTable(
                name: "Studii");

            migrationBuilder.DropTable(
                name: "UserFile");

            migrationBuilder.DropTable(
                name: "DosarRepartitii");

            migrationBuilder.DropTable(
                name: "Olm");

            migrationBuilder.DropTable(
                name: "CnpStudii");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Dosar");

            migrationBuilder.DropTable(
                name: "Cor");

            migrationBuilder.DropTable(
                name: "CnpCalificari");

            migrationBuilder.DropTable(
                name: "Solicitanti");
        }
    }
}
