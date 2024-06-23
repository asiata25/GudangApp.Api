using GudangApp.Api.Data;
using GudangApp.Api.Mapping;

namespace GudangApp.Api.Endpoints;

public static class GudangEndpoints
{
  public static RouteGroupBuilder MapGudangEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("api/v1/gudangs");

    // GET /api/v1/gudangs
    group.MapGet("/", (GudangStoreContext dbContext) => dbContext
    .Gudangs
    .Select(gudang => gudang.ToGudangDetailDto()));

    // POST /api/v1/gudangs
    group.MapPost("/", () => Results.Ok("membuat gudang"));

    // GET /api/v1/gudangs/:id
    group.MapGet("/{id}", (string id) => Results.Ok("id gudang"));

    // PUT /api/v1/gudangs/:id
    group.MapPut("/{id}", (string id) => Results.Ok("put gudang"));

    // DELETE /api/v1/gudangs/:id
    group.MapDelete("/{id}", (string id) => Results.Ok("delete gudang"));

    return group;
  }
}
