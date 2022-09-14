using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.Data.Repositories
{
    public class StateLookupRepository : RepositoryBase, IStateLookupRepository
    {
        public StateLookupRepository(IConfig config) : base(config)
        {
        }

        private Dictionary<Type, object> _inputAndTargetSqlMappings = new()
        {
            {
                typeof(GetStateEitherByIdOrAbbreviation), new SqlAndSqlParamsFuncMap<GetStateEitherByIdOrAbbreviation>(StateProcedures.GetByEitherIdOrAbbreviation,
                    requestObj => requestObj.IsLeft ? new { Id = requestObj.Left, Abbreviation = requestObj.Right } : new { Id = requestObj.Left, Abbreviation = requestObj.Right })
            }
        };

        public Task<int> ExecuteAsync<TInput>(TInput input) => ExecuteAsync(input, _inputAndTargetSqlMappings);

        public Task<TOutput?> FetchAsync<TInput, TOutput>(TInput input) => FetchAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);

        public Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput input) => FetchListAsync<TInput, TOutput>(input, _inputAndTargetSqlMappings);
    }
}
