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
                    requestObj => new {requestObj.Guid, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.StateId, requestObj.PostalCode})
            },
        };

        public async Task<int> ExecuteAsync<TInput>(TInput input) => await ExecuteAsync(input, _inputAndTargetSqlMappings);

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput input) => await FetchAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput input) => await FetchListAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);
    }
}