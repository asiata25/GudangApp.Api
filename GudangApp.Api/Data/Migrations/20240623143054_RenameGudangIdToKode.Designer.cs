﻿// <auto-generated />
using GudangApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GudangApp.Api.Data.Migrations
{
    [DbContext(typeof(GudangStoreContext))]
    [Migration("20240623143054_RenameGudangIdToKode")]
    partial class RenameGudangIdToKode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

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
#pragma warning restore 612, 618
        }
    }
}
