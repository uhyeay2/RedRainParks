using Microsoft.Extensions.Configuration;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Tests
{
    public class TestConfig : IConfig
    {
        public string GetConnectionString(string connectionStringName) => GetIConfigurationRoot()[Domain.Constants.ConfigKeyNames.RedRainParksDbConnectionStringName];

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder().AddJsonFile(Domain.Constants.ConfigKeyNames.AppSettings).Build();

    }
}
