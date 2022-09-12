using RedRainParks.Domain.Interfaces;

namespace RedRainParks.API.Configuration
{
    public class ApiConfig : IConfig
    {
        public string GetConnectionString(string connectionStringName) => GetIConfigurationRoot()[Domain.Constants.ConfigKeyNames.RedRainParksDbConnectionStringName];

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder().AddJsonFile(Domain.Constants.ConfigKeyNames.AppSettings).Build();
    }
}
