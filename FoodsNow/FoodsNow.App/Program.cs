using FoodsNow.DbEntities;
using FoodsNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddRepositories(config);
        services.AddServices(config);
    }).ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
