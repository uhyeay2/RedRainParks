using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.ParkLocationModels.Requests;

namespace RedRainParks.Data.Repositories
{
    internal class ParkLocationRepository : RepositoryBase, IParkLocationRepository
    {
        public ParkLocationRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(GetParkAddressesByIdOrParkCodeRequest), new SqlAndSqlParamsFuncMap<GetParkAddressesByIdOrParkCodeRequest>(
                ParkLocationProcedures.GetParkAddressesByIdOrParkCode, requestObj => new {requestObj.Left, requestObj.Right}) },

                {typeof(InsertParkLocationRequest), new SqlAndSqlParamsFuncMap<InsertParkLocationRequest>(ParkLocationProcedures.InsertParkLocation,
                requestObj => new { requestObj.Guid, requestObj.ParkCode, requestObj.Name, requestObj.IsActive }) }

            };
        }

        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
    }
}
