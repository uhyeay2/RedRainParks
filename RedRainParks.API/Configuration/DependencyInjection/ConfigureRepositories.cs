using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.API.Configuration.DependencyInjection
{
    public static class ConfigureRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            if(services is null)
            {
                throw new ArgumentNullException("Services not found when injecting Repositories");
            }
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IStateLookupRepository, StateLookupRepository>();

            return services;
        }
    }
}
