using FoodsNow.Services.Interfaces;
using FoodsNow.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodsNow.Services
{
    public static class ServicesRegistrationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            serviceCollection.AddTransient<IAppService, AppService>();

            return serviceCollection;
        }
    }
}
