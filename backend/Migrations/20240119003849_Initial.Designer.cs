﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119003849_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Entities.DestinoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("backend.Entities.DestinoReservadoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCheckin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCheckout")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroAdultos")
                        .HasColumnType("int");

                    b.Property<int>("NumeroCriancas")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("DestinoReservado");
                });

            modelBuilder.Entity("backend.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("backend.Entities.DestinoReservadoEntity", b =>
                {
                    b.HasOne("backend.Entities.DestinoEntity", "Destino")
                        .WithMany("DestinoReservados")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Entities.UsuarioEntity", "Usuario")
                        .WithMany("DestinoReservados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("backend.Entities.DestinoEntity", b =>
                {
                    b.Navigation("DestinoReservados");
                });

            modelBuilder.Entity("backend.Entities.UsuarioEntity", b =>
                {
                    b.Navigation("DestinoReservados");
                });
#pragma warning restore 612, 618
        }
    }
}