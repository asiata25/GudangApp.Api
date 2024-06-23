using GudangApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api;

public static class DataExtension
{
  public static void MigrateDb(this WebApplication app) {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GudangStoreContext>();
    dbContext.Database.Migrate();
  }
}
