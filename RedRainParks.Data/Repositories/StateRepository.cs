using RedRainParks.Data.SQL;
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
                { typeof(GetAllStateLookupRequest), new SqlAndSqlParamsFuncMap<GetAllStateLookupRequest>(FetchAll, null!) },

                { typeof(GetStateEitherByIdOrAbbreviation), new SqlAndSqlParamsFuncMap<GetStateEitherByIdOrAbbreviation>(FetchByIdOrAbbreviation, 
                    requestObj =>  new { Id = requestObj.Left, Abbreviation = requestObj.Right }) },
                
                { typeof(IsValidStateLookupIdRequest), new SqlAndSqlParamsFuncMap<IsValidStateLookupIdRequest>(IsValidId, requestObj => new { requestObj.Id }) }
            };
        }

        #region Procedures 

        private static readonly string FetchAll = SqlGenerator.Fetch(typeof(StateLookupDTO));

        private static readonly string FetchByIdOrAbbreviation = SqlGenerator.Fetch(typeof(StateLookupDTO),
            whereOverride: "(Id = @Id OR @Id IS NULL) AND (Abbreviation = @Abbreviation OR @Abbreviation IS NULL)");

        private  static readonly string IsValidId = SharedSql.SelectExists("StateLookup", "Id = @Id");

        #endregion
    }
}
