using GudangApp.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGudangEndpoints();

app.Run();