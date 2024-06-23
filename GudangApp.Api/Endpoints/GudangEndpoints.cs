using GudangApp.Api.Data;
using GudangApp.Api.Dtos;
using GudangApp.Api.Entities;
using GudangApp.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api.Endpoints;

public static class GudangEndpoints
{
  const string GetGudangEndpointName = "GetGudang";

  public static RouteGroupBuilder MapGudangEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("api/v1/gudangs").WithParameterValidation();

    // GET /api/v1/gudangs
    group.MapGet("/", async (GudangStoreContext dbContext) => await dbContext
    .Gudangs
    .Select(gudang => gudang.ToGudangDetailDto())
    .AsNoTracking().ToListAsync());

    // POST /api/v1/gudangs
    group.MapPost("/", async (GudangCreateDto newGudang, GudangStoreContext dbContext) =>
    {
      Gudang gudang = newGudang.ToEntity();

      dbContext.Gudangs.Add(gudang);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetGudangEndpointName, new { kode = gudang.Kode }, gudang.ToGudangDetailDto());
    });

    // GET /api/v1/gudangs/:kode
    group.MapGet("/{kode}", async (string kode, GudangStoreContext dbContext) =>
    {
      Gudang? gudang = await dbContext.Gudangs.FindAsync(kode);

      return gudang is null ? Results.NotFound() : Results.Ok(gudang.ToGudangDetailDto());
    }).WithName(GetGudangEndpointName);

    // PUT /api/v1/gudangs/:kode
    group.MapPut("/{kode}", async (string kode, GudangUpdateDto updatedGudang, GudangStoreContext dbContext) =>
    {
      var existingGudang = await dbContext.Gudangs.FindAsync(kode);

      if (existingGudang is null)
      {
        return Results.NotFound();
      }

      dbContext.Gudangs.Entry(existingGudang)
      .CurrentValues
      .SetValues(updatedGudang.ToEntity(kode));
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    // DELETE /api/v1/gudangs/:kode
    group.MapDelete("/{kode}", async (string kode, GudangStoreContext dbContext) =>
    {
      await dbContext.Gudangs.Where(gudang => gudang.Kode == kode).ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
