using RedRainParks.Data.Procedures;
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
                { typeof(DoesGuidExistRequest), new SqlAndSqlParamsFuncMap<DoesGuidExistRequest>(UsedGuidProcedures.DoesGuidExist, requestObj => new {requestObj.Guid}) },
                { typeof(InsertGuidRequest), new SqlAndSqlParamsFuncMap<InsertGuidRequest>(UsedGuidProcedures.Insert, requestObj => new {requestObj.Guid}) },
                { typeof(DeleteGuidRequest), new SqlAndSqlParamsFuncMap<DeleteGuidRequest>(UsedGuidProcedures.Delete, requestObj => new {requestObj.Guid}) },
            };
        }
    }
}
