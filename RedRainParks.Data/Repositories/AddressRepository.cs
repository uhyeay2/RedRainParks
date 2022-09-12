using Dapper;
using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels.Requests;
using System.Data;

namespace RedRainParks.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(IConfig config) : base(config) { }

        private Dictionary<Type, object> _inputAndTargetSqlMappings = new()
        {
            {
                typeof(GetAddressByIdRequest), new SqlAndSqlParamsFuncMap<GetAddressByIdRequest>(AddressProcedures.GetById, requestObj => new { requestObj.Id })
            },
            {
                typeof(GetAddressByGuidRequest), new SqlAndSqlParamsFuncMap<GetAddressByGuidRequest>(AddressProcedures.GetByGuid, requestObj => new { requestObj.Guid })
            },
            {
                typeof(InsertAddressRequest), new SqlAndSqlParamsFuncMap<InsertAddressRequest>(AddressProcedures.Insert, 
                    requestObj =>
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Guid", requestObj.Guid, DbType.Guid);
                        parameters.Add("Line1", requestObj.Line1, DbType.String);
                        parameters.Add("Line2", requestObj.Line2, DbType.String);
                        parameters.Add("City", requestObj.City, DbType.String);
                        parameters.Add("StateId", requestObj.StateId, DbType.Int32);
                        parameters.Add("PostalCode", requestObj.PostalCode, DbType.String);
                        return parameters;
                    })
            },
        };

        public async Task<int> ExecuteAsync<TInput>(TInput input) => await ExecuteAsync(input, _inputAndTargetSqlMappings);

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput input) => await FetchAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput input) => await FetchListAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);
    }
}