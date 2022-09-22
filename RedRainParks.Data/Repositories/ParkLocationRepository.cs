using RedRainParks.Data.SQL;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.ParkLocationModels;
using RedRainParks.Domain.Models.ParkLocationModels.Requests;

namespace RedRainParks.Data.Repositories
{
    internal class ParkLocationRepository : RepositoryBase, IParkLocationRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }

        public ParkLocationRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(GetParkAddressesByIdOrParkCodeRequest), new SqlAndSqlParamsFuncMap<GetParkAddressesByIdOrParkCodeRequest>(GetAddressesByIdOrParkCode, requestObj => 
                new { Id = requestObj.IsLeft? requestObj.Left : null, ParkCode = !requestObj.IsLeft ? requestObj.Right : null}) },

                { typeof(GetParkLocationByIdOrParkCodeRequest), new SqlAndSqlParamsFuncMap<GetParkLocationByIdOrParkCodeRequest>(GetParkLocationByIdOrParkCode, requestObj => 
                new { Id = requestObj.IsLeft? requestObj.Left : null,  ParkCode = !requestObj.IsLeft ? requestObj.Right : null }) },

                {typeof(InsertParkLocationRequest), new SqlAndSqlParamsFuncMap<InsertParkLocationRequest>(InsertParkLocation, requestObj => 
                new { requestObj.Guid, requestObj.ParkCode, requestObj.Name, requestObj.IsActive }) },

                {typeof(InsertParkAddressRequest), new SqlAndSqlParamsFuncMap<InsertParkAddressRequest>(InsertParkAddress, requestObj => new { 
                requestObj.ParkCode, requestObj.ReferenceName, requestObj.IsActive, requestObj.Rank, requestObj.AddressGuid, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.StateId, requestObj.PostalCode }) },
            };
        }

        #region Procedures

        private static readonly string GetAddressesByIdOrParkCode = SqlGenerator.Fetch(typeof(ParkAddressDTO));

        private static readonly string GetParkLocationByIdOrParkCode = SqlGenerator.Fetch(typeof(ParkLocationDTO));

        private static readonly string InsertParkLocation = SqlGenerator.Insert(typeof(InsertParkLocationRequest));

        private static readonly string InsertParkAddress = SqlGenerator.Insert(typeof(InsertParkAddressRequest));

        #endregion
    }
}
