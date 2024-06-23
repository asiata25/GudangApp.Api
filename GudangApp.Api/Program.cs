using GudangApp.Api;
using GudangApp.Api.Data;
using GudangApp.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("GudangAppDb");
builder.Services.AddSqlite<GudangStoreContext>(connStr);

var app = builder.Build();

app.MapGudangEndpoints();

app.MigrateDb();

app.Run();