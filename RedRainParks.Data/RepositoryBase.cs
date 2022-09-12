using Dapper;
using RedRainParks.Domain.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RedRainParks.Data.Tests")]

namespace RedRainParks.Data
{
    public abstract class RepositoryBase
    {
        private readonly IConfig _config;

        private SqlConnection _connection;

        private string _configKeyName;

        #region Constructors

        internal RepositoryBase(IConfig config, string configKeyName)
        {
            _config = config;
            _configKeyName = configKeyName;
            _connection = GetNewConnection();
        }

        internal RepositoryBase(IConfig config) : this(config, Domain.Constants.ConfigKeyNames.RedRainParksDbConnectionStringName) { }

        #endregion

        #region Protected Queries

        /// <summary>
        /// Use the TInput Request provided to search the inputAndTargetSqlMappings Dictionary for the (ProcName OR InlineSQL) & (Request => Parameters Mapping).
        /// Send the request to Database using Dapper's QueryAsync() to get an IEnumerable of the TOutput requested. Return the FirstOrDefault()
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="request"></param>
        /// <param name="inputAndTargetSqlMappings"></param>
        /// <returns></returns>
        protected async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request, Dictionary<Type, object> inputAndTargetSqlMappings) =>
            (await FetchListAsync<TInput, TOutput>(request, inputAndTargetSqlMappings)).FirstOrDefault();

        /// <summary>
        /// Use the TInput Request provided to search the inputAndTargetSqlMappings Dictionary for the (ProcName OR InlineSQL) & (Request => Parameters Mapping).
        /// Send the request to Database using Dapper's QueryAsync() to return an IEnumerable of the TOutput requested.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="request"></param>
        /// <param name="inputAndTargetSqlMappings"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request, Dictionary<Type, object> inputAndTargetSqlMappings)
        {
            var typedMap = EnsureConnectedAndGetTypedMap(request, inputAndTargetSqlMappings);

            using (_connection)
            {
                _connection.Open();
                return await _connection.QueryAsync<TOutput>(typedMap.ProcNameOrInlineSql, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType);
            }
        }

        /// <summary>
        /// Use the TInput Request provided to search the inputAndTargetSqlMappings Dictionary for the (ProcName OR InlineSQL) & (Request => Parameters Mapping).
        /// Send the request to Database using Dapper's ExecuteAsync()
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="request"></param>
        /// <param name="inputAndTargetSqlMappings"></param>
        /// <returns></returns>
        protected async Task<int> ExecuteAsync<TInput>(TInput request, Dictionary<Type, object> inputAndTargetSqlMappings)
        {
            var typedMap = EnsureConnectedAndGetTypedMap(request, inputAndTargetSqlMappings);

            using (_connection)
            {
                _connection.Open();
                return await _connection.ExecuteAsync(typedMap.ProcNameOrInlineSql, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType);
            }
        }

        protected async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Dictionary<Type, object> inputAndTargetSqlMappings, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id")
        {
            var typedMap = EnsureConnectedAndGetTypedMap(request, inputAndTargetSqlMappings);

            using (_connection)
            {
                _connection.Open();
                return await _connection.QueryAsync(typedMap.ProcNameOrInlineSql, objectMapSettings, typedMap.GetParametersOrDefault(request), commandType: typedMap.CommandType, splitOn: splitOn);
            }
        }

        protected async Task<TOutput?> FetchAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Dictionary<Type, object> inputAndTargetSqlMappings, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") =>
            (await FetchListAsync(request, inputAndTargetSqlMappings, objectMapSettings, splitOn)).FirstOrDefault();

        #endregion

        #region Helpers

        /// <summary>
        /// Use the TInput Request provided to search the inputAndTargetSqlMappings Dictionary for the (ProcName OR InlineSQL) & (Request => Parameters Mapping).
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="request"></param>
        /// <param name="inputandTargetSqlMappings"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private SqlAndSqlParamsFuncMap<TInput> GetTypedMap<TInput>(TInput request, Dictionary<Type, object> inputandTargetSqlMappings) =>
            inputandTargetSqlMappings.TryGetValue(request!.GetType(), out var map) ? (SqlAndSqlParamsFuncMap<TInput>)map : throw new ApplicationException($"There is no mapping created for {request.GetType()}");

        private SqlConnection GetNewConnection() => new(_config.GetConnectionString(_configKeyName));

        private void EnsureConnected() { if (_connection == null || _connection.State == ConnectionState.Closed) _connection = GetNewConnection(); }

        private SqlAndSqlParamsFuncMap<TInput> EnsureConnectedAndGetTypedMap<TInput>(TInput request, Dictionary<Type, object> inputandTargetSqlMappings)
        {
            EnsureConnected();
            return GetTypedMap(request, inputandTargetSqlMappings);
        }

        #endregion
    }
}