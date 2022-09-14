using RedRainParks.API.Configuration.DependencyInjection;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.API.Configuration
{
    public static class ServicesInjection
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("Services not found when InjectingDependencies");
            }

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen();

            services.AddSingleton<IConfig, ApiConfig>();
            
            services.AddRepositories();

            return services;
        }
    }
}
