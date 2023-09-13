using FoodsNow.Services.Interfaces;
using FoodsNow.Services.MappingConfigurations;
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
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IJwtTokenManager, JwtTokenManager>();

            serviceCollection.AddAutoMapper(typeof(AutoMapperProfiles));

            return serviceCollection;
        }
    }
}
