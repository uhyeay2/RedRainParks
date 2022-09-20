using RedRainParks.Data.Procedures;
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
                { typeof(GetAddressByIdRequest), new SqlAndSqlParamsFuncMap<GetAddressByIdRequest>(
                    SqlGenerator.Fetch(typeof(AddressDTO)), requestObj => new { requestObj.Id }) },

                { typeof(GetAddressByGuidRequest), new SqlAndSqlParamsFuncMap<GetAddressByGuidRequest>(
                    SqlGenerator.Fetch(typeof(AddressDTO), whereOverride: "WHERE Address.Guid = @Guid"), requestObj => new { requestObj.Guid }) },

                { typeof(InsertAddressRequest), new SqlAndSqlParamsFuncMap<InsertAddressRequest>(AddressProcedures.Insert,
                requestObj => new {requestObj.Guid, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.StateId, requestObj.PostalCode}) },

                { typeof(UpdateAddressByIdRequest), new SqlAndSqlParamsFuncMap<UpdateAddressByIdRequest>(AddressProcedures.UpdateById,
                requestObj => new { requestObj.Id, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.PostalCode, requestObj.State }) },

                { typeof(DeleteAddressByIdRequest), new SqlAndSqlParamsFuncMap<DeleteAddressByIdRequest>(AddressProcedures.DeleteById, requestObj => new { requestObj.Id }) }
            };
        }
    }
}