using Dapper;
using RedRainParks.Domain.Interfaces;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("RedRainParks.Data.Tests")]

namespace RedRainParks.Data
{
    public abstract class RepositoryBase
    {
        private readonly IConfig _config;

        private string _configKeyName;

        protected abstract Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }

        #region Constructors

        internal RepositoryBase(IConfig config, string configKeyName)
        {
            _config = config;
            _configKeyName = configKeyName;
        }

        internal RepositoryBase(IConfig config) : this(config, Domain.Constants.ConfigKeyNames.RedRainParksDbConnectionStringName) { }

        #endregion

        #region Exposed Methods

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) => (await FetchListAsync<TInput, TOutput>(request)).FirstOrDefault();

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request)
        {
            var typedMap = GetTypedMap(request);

            using var connection = GetNewConnection();

            connection.Open();

            return await connection.QueryAsync<TOutput>(typedMap.ProcNameOrInlineSql, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType);
        }

        public async Task<int> ExecuteAsync<TInput>(TInput request)
        {
            var typedMap = GetTypedMap(request);

            using var connection = GetNewConnection();

            connection.Open();

            return await connection.ExecuteAsync(typedMap.ProcNameOrInlineSql, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType);
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id")
        {
            var typedMap = GetTypedMap(request);

            using var connection = GetNewConnection();

            connection.Open();
            
            return await connection.QueryAsync(typedMap.ProcNameOrInlineSql, objectMapSettings, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType, splitOn: splitOn);
        }

        public async Task<TOutput?> FetchAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") =>
            (await FetchListAsync(request, objectMapSettings, splitOn)).FirstOrDefault();

        #endregion

        #region Helpers
    
        private SqlAndSqlParamsFuncMap<TInput> GetTypedMap<TInput>(TInput request)
        {
            if (request == null) throw new ApplicationException("Null Request Received When Getting TypedMap");

            return _inputAndTargetSqlMappings.TryGetValue(request.GetType(), out var map) ? (SqlAndSqlParamsFuncMap<TInput>)map 
                : throw new ApplicationException($"There is no mapping created for {request.GetType()}");
        }

        private System.Data.SqlClient.SqlConnection GetNewConnection() => new(_config.GetConnectionString(_configKeyName));

        #endregion
    }
}