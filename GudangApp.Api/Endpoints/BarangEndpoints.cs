using GudangApp.Api.Data;
using GudangApp.Api.Dtos;
using GudangApp.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api;

public static class BarangEndpoints
{
  public static RouteGroupBuilder MapBarangEndpoint(this WebApplication app)
  {
    var group = app.MapGroup("api/v1/barangs").WithParameterValidation();

    // POST /api/v1/barangs
    group.MapPost("/", async (BarangCreateDto newBarang, GudangStoreContext dbContext) =>
    {
      Barang barang = newBarang.ToEntity();

      await dbContext.Barangs.AddAsync(barang);
      dbContext.SaveChanges();

      // TODO: refactor this to Result.CreatedWith...
      return Results.Ok();
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
