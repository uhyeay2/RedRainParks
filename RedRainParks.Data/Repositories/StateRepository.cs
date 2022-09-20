using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels;
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
                    typeof(GetStateEitherByIdOrAbbreviation), new SqlAndSqlParamsFuncMap<GetStateEitherByIdOrAbbreviation>(
                        SqlGenerator.Fetch(typeof(StateLookupDTO), whereOverride: "WHERE (Id = @Id OR @Id IS NULL) AND (Abbreviation = @Abbreviation OR @Abbreviation IS NULL)"), 
                        requestObj =>  new { Id = requestObj.Left, Abbreviation = requestObj.Right })
                },
                {
                    typeof(GetAllStateLookupRequest), new SqlAndSqlParamsFuncMap<GetAllStateLookupRequest>(
                        SqlGenerator.Fetch(typeof(StateLookupDTO)), null!)
                },
                {
                    typeof(IsValidStateLookupIdRequest), new SqlAndSqlParamsFuncMap<IsValidStateLookupIdRequest>(
                        SharedSql.SelectExists("StateLookup", "Id = @Id"), requestObj => new { requestObj.Id })
                }
            };
        }
    }
}
