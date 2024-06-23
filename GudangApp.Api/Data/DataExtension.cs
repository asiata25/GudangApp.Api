using GudangApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GudangApp.Api;

public static class DataExtension
{
  public static async void MigrateDbAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GudangStoreContext>();
    await dbContext.Database.MigrateAsync();
  }
}
