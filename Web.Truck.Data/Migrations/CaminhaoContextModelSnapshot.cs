﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Truck.Data.Context;

namespace Web.Truck.Data.Migrations
{
    [DbContext(typeof(CaminhaoContext))]
    partial class CaminhaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Web.Truck.Domain.Entities.Caminhao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chassi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataCadastroUtc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ModeloId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Caminhao");
                });

            modelBuilder.Entity("Web.Truck.Domain.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataCadastroUtc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("Web.Truck.Domain.Entities.Caminhao", b =>
                {
                    b.HasOne("Web.Truck.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Caminhaos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Web.Truck.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Caminhaos");
                });
#pragma warning restore 612, 618
        }
    }
}