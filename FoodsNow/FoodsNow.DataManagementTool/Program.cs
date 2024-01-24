using FoodsNow.DbEntities;
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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();