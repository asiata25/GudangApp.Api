using GudangApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api.Data;

public class GudangStoreContext(DbContextOptions<GudangStoreContext> options) : DbContext(options)
{
  public DbSet<Gudang> Gudangs => Set<Gudang>();
  public DbSet<Barang> Barangs => Set<Barang>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Gudang>()
    .ToTable("gudang")
    .HasKey(g => g.Kode);

    modelBuilder.Entity<Gudang>()
    .Property(g => g.Kode)
    .HasColumnName("kode");

    modelBuilder.Entity<Gudang>()
    .Property(g => g.Nama)
    .HasColumnName("nama");

    modelBuilder.Entity<Barang>()
    .ToTable("barang")
    .HasKey(b => b.Kode);

    modelBuilder.Entity<Barang>()
    .Property(b => b.Kode)
    .HasColumnName("kode");

    modelBuilder.Entity<Barang>()
    .Property(b => b.Nama)
    .HasColumnName("nama");
    
    modelBuilder.Entity<Barang>()
    .Property(b => b.Harga)
    .HasColumnName("harga");

    modelBuilder.Entity<Barang>()
    .Property(b => b.Jumlah)
    .HasColumnName("jumlah");

    modelBuilder.Entity<Barang>()
    .Property(b => b.Expired)
    .HasColumnName("expired");

    modelBuilder.Entity<Barang>()
    .Property(b => b.KodeGudang)
    .HasColumnName("kode_gudang");
  }
}
