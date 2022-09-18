using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.LoggingModels.Requests;
using RedRainParks.Data.Procedures;

namespace RedRainParks.Data.Repositories
{
    internal class LoggingRepository : RepositoryBase, ILoggingRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }

        public LoggingRepository(IConfig config, string configKeyName) : base(config, configKeyName)
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(InsertExceptionLogRequest), new SqlAndSqlParamsFuncMap<InsertExceptionLogRequest>(LoggingProcedures.InsertExceptionLog, requestObj => new 
                    { requestObj.CreatedBy, requestObj.RequestHeaders, requestObj.RequestBody, requestObj.Message, requestObj.Source, requestObj.StackTrace })
                }
            };
        }
    }
}
