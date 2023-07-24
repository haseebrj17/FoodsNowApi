using FoodsNow.DbEntities.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodsNow.DbEntities
{
    public static class RepositoriesRegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            serviceCollection.AddTransient<IClientRepository, ClientRepository>();
            serviceCollection.AddTransient<IFranchiseRepository, FranchiseRepository>();
            serviceCollection.AddTransient<IBannerRepository, BannerRepository>();
            serviceCollection.AddTransient<IBannerRepository, BannerRepository>();

            return serviceCollection;
        }
    }
}
