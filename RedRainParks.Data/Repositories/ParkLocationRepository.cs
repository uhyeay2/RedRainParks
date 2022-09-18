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
                { typeof(GetParkAddressesByIdOrParkCodeRequest), new SqlAndSqlParamsFuncMap<GetParkAddressesByIdOrParkCodeRequest>(ParkLocationProcedures.GetAddressesByIdOrParkCode,
                requestObj => new { Id = requestObj.IsLeft? requestObj.Left : null, ParkCode = !requestObj.IsLeft ? requestObj.Right : null}) },

                {typeof(InsertParkLocationRequest), new SqlAndSqlParamsFuncMap<InsertParkLocationRequest>(ParkLocationProcedures.InsertParkLocation,
                requestObj => new { requestObj.Guid, requestObj.ParkCode, requestObj.Name, requestObj.IsActive }) },

                { typeof(GetParkLocationByIdOrParkCodeRequest), new SqlAndSqlParamsFuncMap<GetParkLocationByIdOrParkCodeRequest>(ParkLocationProcedures.GetLocationByIdOrParkCode, 
                requestObj => new { Id = requestObj.IsLeft? requestObj.Left : null, ParkCode = !requestObj.IsLeft ? requestObj.Right : null}) },
            };
        }

        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
    }
}
