﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGWiki.Shared.Data.BD;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    [DbContext(typeof(RPGWikiContext))]
    [Migration("20240725002334_RelateJogadorMissao")]
    partial class RelateJogadorMissao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JogadorMissao", b =>
                {
                    b.Property<int>("jogadoresId")
                        .HasColumnType("int");

                    b.Property<int>("missoesId")
                        .HasColumnType("int");

                    b.HasKey("jogadoresId", "missoesId");

                    b.HasIndex("missoesId");

                    b.ToTable("JogadorMissao");
                });

            modelBuilder.Entity("RPGWiki.Shared.Models.Missao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dificuldade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Missoes");
                });

            modelBuilder.Entity("RPGWiki_Console.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Moedas")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jogador");
                });

            modelBuilder.Entity("RPGWiki_Console.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("JogadorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<int>("Vida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.ToTable("Personagem");
                });

            modelBuilder.Entity("JogadorMissao", b =>
                {
                    b.HasOne("RPGWiki_Console.Jogador", null)
                        .WithMany()
                        .HasForeignKey("jogadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGWiki.Shared.Models.Missao", null)
                        .WithMany()
                        .HasForeignKey("missoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPGWiki_Console.Personagem", b =>
                {
                    b.HasOne("RPGWiki_Console.Jogador", "Jogador")
                        .WithMany("personagens")
                        .HasForeignKey("JogadorId");

                    b.Navigation("Jogador");
                });

            modelBuilder.Entity("RPGWiki_Console.Jogador", b =>
                {
                    b.Navigation("personagens");
                });
#pragma warning restore 612, 618
        }
    }
}