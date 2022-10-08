using Dapper;
using RedRainParks.Domain.Interfaces;
using System.Data.SqlClient;

namespace DataRequestHandler
{
    public class DataHandler : IDataHandler
    {
        private readonly IConfig _config;
        private readonly string _configSection;

        public DataHandler(IConfig config, string configSection)
        {
            _configSection = configSection;
            _config = config;
        }

        public DataHandler(IConfig config) : this(config, RedRainParks.Domain.Constants.ConfigKeyNames.RedRainParksDbConnectionStringName) { }

        public async Task<int> ExecuteAsync<TInput>(TInput request) where TInput : IRequestObject
        {
            using var connection = new SqlConnection(_config.GetConnectionString(_configSection));

            connection.Open();

            return await connection.ExecuteAsync(request.GenerateSql(), request.GenerateParameters());
        }

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject
        {
            using var connection = new SqlConnection(_config.GetConnectionString(_configSection));

            connection.Open();

            return (await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters())).FirstOrDefault();
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject
        {
            using var connection = new SqlConnection(_config.GetConnectionString(_configSection));

            connection.Open();

            return await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }
    }
}
