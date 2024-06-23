using GudangApp.Api.Data;
using GudangApp.Api.Dtos;
using GudangApp.Api.Entities;
using GudangApp.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api;

public static class BarangEndpoints
{
  const string GetBarangEndpointName = "GetBarang";

  public static RouteGroupBuilder MapBarangEndpoint(this WebApplication app)
  {
    var group = app.MapGroup("api/v1/barangs").WithParameterValidation();

    // GET /api/v1/barangs
    group.MapGet("/", async (GudangStoreContext dbContext) =>
      await dbContext.Barangs
      .Include(barang => barang.Gudang)
      .Select(barang => barang.ToBarangDetailsDto())
      .AsNoTracking().ToListAsync()
    );

    // GET /api/v1/barangs/:kode
    group.MapGet("/{kode}", async (string kode, GudangStoreContext dbContext) =>
    {
      Barang? barang = await dbContext.Barangs.Include(barang => barang.Gudang).FirstAsync(barang => barang.Kode == kode);

      return barang is null ? Results.NotFound() : Results.Ok(barang.ToBarangDetailsDto());
    }).WithName(GetBarangEndpointName);

    // POST /api/v1/barangs
    group.MapPost("/", async (BarangCreateDto newBarang, GudangStoreContext dbContext) =>
    {
      Barang barang = newBarang.ToEntity();

      await dbContext.Barangs.AddAsync(barang);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetBarangEndpointName, new { kode = barang.Kode }, barang.ToBarangDetailsDto());
    });

    // DELETE /api/v1/barangs/:kode
    group.MapDelete("/{kode}", async (string kode, GudangStoreContext dbContext) =>
    {
      await dbContext.Barangs.Where(barang => barang.Kode == kode).ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
