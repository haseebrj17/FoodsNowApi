using FoodsNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using FoodsNow.DbEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using FoodsNow.Services.BlobStorage.Interfaces;
using FoodsNow.Services.BlobStorage.Services;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<Program>();

try
{
    var config = new ConfigurationBuilder()
        .AddJsonFile("local.settings.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    var cosmosDbConString = config.GetValue<string>("CosmosDb:ConnectionString") ??
        "AccountEndpoint=https://byteznowcdb.documents.azure.com:443/;AccountKey=9NHhOaOq21tUSGfjtnyWIItejTUwQ5bI6nPdOuhIwrmFLnmJz3WaRYWKp0CqcsxcrxJVedO4d4t2ACDb3Ueg8A==;";
    var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName") ??
        "BytezNowDB";

    var host = new HostBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<FoodsNowDbContext>(options =>
                options.UseCosmos(
                    cosmosDbConString,
                    databaseName: cosmosDbDatabaseName
                ));

            services.AddRepositories(config);
            services.AddServices(config);
            services.AddAutoMapper(typeof(Program));

        }).ConfigureFunctionsWorkerDefaults()
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    logger.LogCritical("JW: " + ex.Message);
}