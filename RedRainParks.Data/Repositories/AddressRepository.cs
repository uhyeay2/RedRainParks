using RedRainParks.Data.SQL;
using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
        
        public AddressRepository(IConfig config) : base(config) 
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(GetAddressByIdRequest), new SqlAndSqlParamsFuncMap<GetAddressByIdRequest>(GetById, requestObj => new { requestObj.Id }) },

                { typeof(GetAddressByGuidRequest), new SqlAndSqlParamsFuncMap<GetAddressByGuidRequest>(GetByGuid, requestObj => new { requestObj.Guid }) },

                { typeof(InsertAddressRequest), new SqlAndSqlParamsFuncMap<InsertAddressRequest>(Insert, requestObj => 
                new {requestObj.Guid, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.StateId, requestObj.PostalCode}) },

                { typeof(UpdateAddressByIdRequest), new SqlAndSqlParamsFuncMap<UpdateAddressByIdRequest>(UpdateById, requestObj => 
                new { requestObj.Id, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.PostalCode, requestObj.State }) },

                { typeof(DeleteAddressByIdRequest), new SqlAndSqlParamsFuncMap<DeleteAddressByIdRequest>(DeleteById, requestObj => new { requestObj.Id }) }
            };
        }

        #region Procedures

        private static readonly string GetById = SqlGenerator.Fetch(typeof(AddressDTO));

        private static readonly string GetByGuid = SqlGenerator.Fetch(typeof(AddressDTO), whereOverride: "Address.Guid = @Guid");

        private static readonly string UpdateById = SharedSql.CoalesceUpdate("Address", typeof(UpdateAddressByIdRequest).GetSqlPropertyNames(), "Address.Id = @Id");

        private static readonly string DeleteById = SharedSql.Delete("Address", "Id = @Id");

        private const string Insert = "PROC_INSERT_Address";

        #endregion
    }
}