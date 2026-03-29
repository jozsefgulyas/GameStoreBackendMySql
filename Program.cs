using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();
app.MapCustomersEndpoints();
app.MapOrdersEndpoints();

await app.MigrateDbAsync();

app.Run();
