﻿// <auto-generated />
using BackEndDronMedicamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndDronMedicamento.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221001145259_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEndDronMedicamento.Entidades.Dron", b =>
                {
                    b.Property<string>("NumeroSerie")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CapacidadBateria")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PesoLimite")
                        .HasColumnType("int");

                    b.HasKey("NumeroSerie");

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("BackEndDronMedicamento.Entidades.DronMedicamento", b =>
                {
                    b.Property<string>("CodigoDron")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoDron");

                    b.ToTable("DronMedicamentos");
                });

            modelBuilder.Entity("BackEndDronMedicamento.Entidades.Medicamento", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.ToTable("Medicamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
