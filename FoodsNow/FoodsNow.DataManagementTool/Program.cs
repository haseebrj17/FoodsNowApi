using FoodsNow.DbEntities;
using FoodsNow.DataManagementTool.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var cosmosDbConString = configuration.GetConnectionString("CosmosDb:ConnectionString") ??
    "AccountEndpoint=https://byteznowcdb.documents.azure.com:443/;AccountKey=9NHhOaOq21tUSGfjtnyWIItejTUwQ5bI6nPdOuhIwrmFLnmJz3WaRYWKp0CqcsxcrxJVedO4d4t2ACDb3Ueg8A==;";
var cosmosDbDatabaseName = configuration.GetConnectionString("CosmosDb:DatabaseName") ??
    "BytezNowDB";

builder.Services.AddDbContext<FoodsNowDbContext>(options =>
options.UseCosmos(
    cosmosDbConString,
    databaseName: cosmosDbDatabaseName
));


builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

await InitializeDatabase(app);

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync();
}

app.MapGet("/", () => "Hello World!");

app.Run();

async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<FoodsNowDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}