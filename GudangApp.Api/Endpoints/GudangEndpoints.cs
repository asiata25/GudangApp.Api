using GudangApp.Api.Data;
using GudangApp.Api.Entities;
using GudangApp.Api.Mapping;

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
      Gudang gudang = newGudang.ToGudangEntity();

      dbContext.Gudangs.Add(gudang);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetGudangEndpointName, new { kode = gudang.Kode }, gudang.ToGudangDetailDto());
    });

    // GET /api/v1/gudangs/:kode
    group.MapGet("/{kode}", (string kode) => Results.Ok("kode gudang")).WithName(GetGudangEndpointName);

    // PUT /api/v1/gudangs/:kode
    group.MapPut("/{kode}", (string kode) => Results.Ok("put gudang"));

    // DELETE /api/v1/gudangs/:kode
    group.MapDelete("/{kode}", (string kode) => Results.Ok("delete gudang"));

    return group;
  }
}
