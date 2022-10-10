using DataRequestHandler;
using DataRequestHandler.Interfaces;
using DataRequestMediator;
using FluentValidation;
using RedRainParks.API.Middleware;
using RedRainParks.DataAccessMediator.Behaviors;
using RedRainParks.DataAccessMediator.Mappings;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.API.Configuration.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<IConfig, ApiConfig>();
            services.AddTransient<IDataHandler, DataHandler>();

            var assembly = typeof(DataRequestMediatorEntryPoint).Assembly;
            services.AddSingleton(MappingProfiles.GetMapperConfiguration().CreateMapper());
            services.AddMediatR(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
