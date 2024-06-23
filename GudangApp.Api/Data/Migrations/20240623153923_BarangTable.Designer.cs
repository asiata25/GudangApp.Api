﻿// <auto-generated />
using System;
using GudangApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    [DbContext(typeof(GudangStoreContext))]
    [Migration("20240623153923_BarangTable")]
    partial class BarangTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("GudangApp.Api.Barang", b =>
                {
                    b.Property<string>("Kode")
                        .HasColumnType("TEXT")
                        .HasColumnName("kode");

                    b.Property<DateOnly>("Expired")
                        .HasColumnType("TEXT")
                        .HasColumnName("expired");

                    b.Property<string>("GudangKode")
                        .HasColumnType("TEXT");

                    b.Property<int>("Harga")
                        .HasColumnType("INTEGER")
                        .HasColumnName("harga");

                    b.Property<int>("Jumlah")
                        .HasColumnType("INTEGER")
                        .HasColumnName("jumlah");

                    b.Property<string>("KodeGudang")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("kode_gudang");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nama");

                    b.HasKey("Kode");

                    b.HasIndex("GudangKode");

                    b.ToTable("barang", (string)null);
                });

            modelBuilder.Entity("GudangApp.Api.Entities.Gudang", b =>
                {
                    b.Property<string>("Kode")
                        .HasColumnType("TEXT")
                        .HasColumnName("kode");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nama");

                    b.HasKey("Kode");

                    b.ToTable("gudang", (string)null);
                });

            modelBuilder.Entity("GudangApp.Api.Barang", b =>
                {
                    b.HasOne("GudangApp.Api.Entities.Gudang", "Gudang")
                        .WithMany()
                        .HasForeignKey("GudangKode");

                    b.Navigation("Gudang");
                });
#pragma warning restore 612, 618
        }
    }
}