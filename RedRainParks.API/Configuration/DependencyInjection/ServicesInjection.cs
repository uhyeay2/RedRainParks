﻿using DataRequestHandler;
using DataRequestHandler.Interfaces;
using DataRequestMediator;
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

            services.AddSingleton(MappingProfiles.GetMapperConfiguration().CreateMapper());

            services.AddTransient<IDataHandler, DataHandler>();

            services.AddMediatR(typeof(DataRequestMediatorEntryPoint).Assembly);

            return services;
        }
    }
}
