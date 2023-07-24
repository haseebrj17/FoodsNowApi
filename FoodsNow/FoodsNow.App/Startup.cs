using FoodsNow.App;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FoodsNow.Services;
using FoodsNow.DbEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FoodsNow.App
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var serviceCollection = builder.Services;

            builder.Services.AddDbContext<FoodsNowDbContext>(options => options.UseSqlServer(config.GetValue<string>("FoodsNowDb")));

            serviceCollection.AddRepositories(config);

            serviceCollection.AddServices(config);
        }
    }
}
