using GudangApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api.Data;

public class GudangStoreContext(DbContextOptions<GudangStoreContext> options) : DbContext(options)
{
  public DbSet<Gudang> Gudangs => Set<Gudang>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Gudang>()
    .ToTable("gudang")
    .Property(g => g.Id)
    .HasColumnName("id");

    modelBuilder.Entity<Gudang>()
    .Property(g => g.Nama)
    .HasColumnName("nama");
  }
}
