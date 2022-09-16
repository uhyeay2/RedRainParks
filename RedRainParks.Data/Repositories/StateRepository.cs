using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.Data.Repositories
{
    public class StateLookupRepository : RepositoryBase, IStateLookupRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }

        public StateLookupRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new()
            {
                {
                    typeof(GetStateEitherByIdOrAbbreviation), new SqlAndSqlParamsFuncMap<GetStateEitherByIdOrAbbreviation>(StateLookupProcedures.GetByEitherIdOrAbbreviation,
                        requestObj => requestObj.IsLeft ? new { Id = requestObj.Left, Abbreviation = requestObj.Right } : new { Id = requestObj.Left, Abbreviation = requestObj.Right })
                },
                {
                    typeof(GetAllStateLookupRequest), new SqlAndSqlParamsFuncMap<GetAllStateLookupRequest>(StateLookupProcedures.GetAll, null!)
                }
            };
        }
    }
}
