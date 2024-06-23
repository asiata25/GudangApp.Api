using GudangApp.Api.Data;
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
    group.MapGet("/", (GudangStoreContext dbContext) => dbContext
    .Gudangs
    .Select(gudang => gudang.ToGudangDetailDto()));

    // POST /api/v1/gudangs
    group.MapPost("/", (GudangCreateDto newGudang, GudangStoreContext dbContext) =>
    {
      Gudang gudang = newGudang.ToEntity();

      dbContext.Gudangs.Add(gudang);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetGudangEndpointName, new { kode = gudang.Kode }, gudang.ToGudangDetailDto());
    });

    // GET /api/v1/gudangs/:kode
    group.MapGet("/{kode}", (string kode, GudangStoreContext dbContext) =>
    {
      Gudang? gudang = dbContext.Gudangs.Find(kode);

      return gudang is null ? Results.NotFound() : Results.Ok(gudang.ToGudangDetailDto());
    }).WithName(GetGudangEndpointName);

    // PUT /api/v1/gudangs/:kode
    group.MapPut("/{kode}", (string kode, GudangUpdateDto updatedGudang, GudangStoreContext dbContext) =>
    {
      var existingGudang = dbContext.Gudangs.Find(kode);

      if (existingGudang is null)
      {
        return Results.NotFound();
      }

      dbContext.Gudangs.Entry(existingGudang)
      .CurrentValues
      .SetValues(updatedGudang.ToEntity(kode));
      dbContext.SaveChanges();

      return Results.NoContent();
    });

    // DELETE /api/v1/gudangs/:kode
    group.MapDelete("/{kode}", (string kode, GudangStoreContext dbContext) =>
    {
      dbContext.Gudangs.Where(gudang => gudang.Kode == kode).ExecuteDelete();

      return Results.NoContent();
    });

    return group;
  }
}
