using RedRainParks.Data.SQL;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.UsedGuidModels.Requests;

namespace RedRainParks.Data.Repositories
{
    public class UsedGuidsRepository : RepositoryBase, IUsedGuidsRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
        public UsedGuidsRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(DoesGuidExistRequest), new SqlAndSqlParamsFuncMap<DoesGuidExistRequest>(DoesGuidExist, requestObj => new {requestObj.Guid}) },

                { typeof(InsertGuidRequest), new SqlAndSqlParamsFuncMap<InsertGuidRequest>(Insert, requestObj => new {requestObj.Guid}) },

                { typeof(DeleteGuidRequest), new SqlAndSqlParamsFuncMap<DeleteGuidRequest>(Delete, requestObj => new {requestObj.Guid}) },
            };
        }

        #region Procedures

        private const string Insert = "INSERT INTO UsedGuid (UniqueIdentifier) VALUES (@Guid)";

        private static readonly string DoesGuidExist = SharedSql.SelectExists("UsedGuid", "UniqueIdentifier = @Guid");

        private static readonly string Delete = SharedSql.Delete("UsedGuid", "UniqueIdentifier = @Guid");

        #endregion
    }
}
