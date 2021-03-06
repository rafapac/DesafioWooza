﻿// <auto-generated />
using System;
using DesafioWooza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioWooza.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200309004454_MigrationInicial")]
    partial class MigrationInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioWooza.Models.PlanoTelefonia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("FkPlanoTelefoniaTipo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FranquiaInternet")
                        .HasColumnType("int");

                    b.Property<int>("Minutos")
                        .HasColumnType("int");

                    b.Property<string>("Operadora")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("FkPlanoTelefoniaTipo");

                    b.ToTable("PlanoTelefonia");
                });

            modelBuilder.Entity("DesafioWooza.Models.PlanoTelefoniaDDD", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<Guid>("FkPlanoTelefonia")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FkPlanoTelefonia");

                    b.ToTable("PlanoTelefoniaDDD");
                });

            modelBuilder.Entity("DesafioWooza.Models.PlanoTelefoniaTipo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PlanoTelefoniaTipo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91866764-ea96-4cbe-91f8-a10e36531f32"),
                            Tipo = "Controle"
                        },
                        new
                        {
                            Id = new Guid("ee042bad-ec64-40d2-b7bb-e842871034c5"),
                            Tipo = "Pós"
                        },
                        new
                        {
                            Id = new Guid("586d945a-a904-46c6-9b59-5fb16026a80c"),
                            Tipo = "Pré"
                        });
                });

            modelBuilder.Entity("DesafioWooza.Models.PlanoTelefonia", b =>
                {
                    b.HasOne("DesafioWooza.Models.PlanoTelefoniaTipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("FkPlanoTelefoniaTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioWooza.Models.PlanoTelefoniaDDD", b =>
                {
                    b.HasOne("DesafioWooza.Models.PlanoTelefonia", "Plano")
                        .WithMany("DDDs")
                        .HasForeignKey("FkPlanoTelefonia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
