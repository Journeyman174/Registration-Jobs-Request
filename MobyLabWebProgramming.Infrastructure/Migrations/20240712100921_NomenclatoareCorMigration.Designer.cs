﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobyLabWebProgramming.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    [DbContext(typeof(WebAppDatabaseContext))]
    [Migration("20240712100921_NomenclatoareCorMigration")]
    partial class NomenclatoareCorMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "unaccent");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.CnpCalificari", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CnpSolicitant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdCor")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSolicitant")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CorId");

                    b.HasIndex("IdCor");

                    b.ToTable("CnpCalificari");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.CnpStudii", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CnpSolicitant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdSolicitant")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdStudii")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudiiId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdStudii");

                    b.HasIndex("StudiiId");

                    b.ToTable("CnpStudii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Cor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodCor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Meserie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cor");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Dosar", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CnpSolicitant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataDosar")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeLa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdSolicitant")
                        .HasColumnType("uuid");

                    b.Property<string>("NrDosar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PanaLa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Stare")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("NrDosar");

                    b.HasIndex("UserId");

                    b.ToTable("Dosar");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.DosarRepartitii", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DosarId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdDosar")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRepartitie")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DosarId");

                    b.ToTable("DosarRepartitii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Olm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdresaLocMunca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Agent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CuiFirma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataOlm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataOlmSfarsit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataOlmStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdCor")
                        .HasColumnType("uuid");

                    b.Property<int>("NrLocMunca")
                        .HasColumnType("integer");

                    b.Property<string>("Stare")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CorId");

                    b.HasIndex("UserId");

                    b.ToTable("Olm");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Repartitie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CNP")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataRepartitie")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DosarRId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DosarRepartitiiId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdDosar")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdOlm")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RepartitiiOlmId")
                        .HasColumnType("uuid");

                    b.Property<string>("Rezultat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DosarRId");

                    b.HasIndex("DosarRepartitiiId");

                    b.HasIndex("RepartitiiOlmId");

                    b.HasIndex("UserId");

                    b.ToTable("Repartitie");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Solicitanti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnpSolicitant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInregistare")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("CnpSolicitant");

                    b.HasIndex("UserId");

                    b.ToTable("Solicitanti");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Studii", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DenStudii")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Studii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.UserFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(4095)
                        .HasColumnType("character varying(4095)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserFile");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.CnpCalificari", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Cor", "Cor")
                        .WithMany("Lucratori")
                        .HasForeignKey("CorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.Solicitanti", "Solicitanti")
                        .WithMany("Calificari")
                        .HasForeignKey("IdCor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cor");

                    b.Navigation("Solicitanti");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.CnpStudii", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Solicitanti", "Solicitanti")
                        .WithMany("Pregatire")
                        .HasForeignKey("IdStudii")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.Studii", "Studii")
                        .WithMany("Persoane")
                        .HasForeignKey("StudiiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitanti");

                    b.Navigation("Studii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Cor", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Dosar", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Solicitanti", "Solicitanti")
                        .WithMany("Dosare")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany("Dosare")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitanti");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.DosarRepartitii", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Dosar", "Dosar")
                        .WithMany("Repartitii")
                        .HasForeignKey("DosarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dosar");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Olm", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Cor", "Cor")
                        .WithMany()
                        .HasForeignKey("CorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Repartitie", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.Dosar", "DosarR")
                        .WithMany()
                        .HasForeignKey("DosarRId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.DosarRepartitii", null)
                        .WithMany("Repartitii")
                        .HasForeignKey("DosarRepartitiiId");

                    b.HasOne("MobyLabWebProgramming.Core.Entities.Olm", "RepartitiiOlm")
                        .WithMany("Repartitii")
                        .HasForeignKey("RepartitiiOlmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DosarR");

                    b.Navigation("RepartitiiOlm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Solicitanti", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", null)
                        .WithMany("Solicitanti")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Studii", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.UserFile", b =>
                {
                    b.HasOne("MobyLabWebProgramming.Core.Entities.User", "User")
                        .WithMany("UserFiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Cor", b =>
                {
                    b.Navigation("Lucratori");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Dosar", b =>
                {
                    b.Navigation("Repartitii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.DosarRepartitii", b =>
                {
                    b.Navigation("Repartitii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Olm", b =>
                {
                    b.Navigation("Repartitii");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Solicitanti", b =>
                {
                    b.Navigation("Calificari");

                    b.Navigation("Dosare");

                    b.Navigation("Pregatire");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.Studii", b =>
                {
                    b.Navigation("Persoane");
                });

            modelBuilder.Entity("MobyLabWebProgramming.Core.Entities.User", b =>
                {
                    b.Navigation("Dosare");

                    b.Navigation("Solicitanti");

                    b.Navigation("UserFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
