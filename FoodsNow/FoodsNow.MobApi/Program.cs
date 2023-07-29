using FoodsNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using FoodsNow.DbEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var connectionString = config.GetValue<string>("FoodsNowDb") ?? 
    "Server=tcp:foods-now-db-server.database.windows.net,1433;Initial Catalog=FoodsNowDb;Persist Security Info=False;User ID=FoodsUser;Password=Haseeb@1949;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddDbContext<FoodsNowDbContext>(options =>
    options.UseSqlServer(connectionString));

        services.AddRepositories(config);
        services.AddServices(config);

    }).ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
