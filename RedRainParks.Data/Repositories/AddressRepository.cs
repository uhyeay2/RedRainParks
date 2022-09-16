using RedRainParks.Data.Procedures;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels.Requests;
using Dapper;
using System.Data;

namespace RedRainParks.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }
        
        public AddressRepository(IConfig config) : base(config) 
        {
            _inputAndTargetSqlMappings = new()
            {
                {
                    typeof(GetAddressByIdRequest), new SqlAndSqlParamsFuncMap<GetAddressByIdRequest>(AddressProcedures.GetById, requestObj => new { requestObj.Id })
                },
                {
                    typeof(GetAddressByGuidRequest), new SqlAndSqlParamsFuncMap<GetAddressByGuidRequest>(AddressProcedures.GetByGuid, requestObj => new { requestObj.Guid })
                },
                {
                    typeof(InsertAddressRequest), new SqlAndSqlParamsFuncMap<InsertAddressRequest>(AddressProcedures.Insert,
                        requestObj => new {requestObj.Guid, requestObj.Line1, requestObj.Line2, requestObj.City, requestObj.StateId, requestObj.PostalCode})
                },
                {   typeof(UpdateAddressByIdRequest), new SqlAndSqlParamsFuncMap<UpdateAddressByIdRequest>(AddressProcedures.UpdateById,
                        requestObj =>
                        {
                            var parameters = new DynamicParameters();
                                parameters.Add(nameof(requestObj.Id), requestObj.Id, DbType.Int32);
                                parameters.Add(nameof(requestObj.Line1), requestObj.Line1, DbType.String);
                                parameters.Add(nameof(requestObj.Line2), requestObj.Line2, DbType.String);
                                parameters.Add(nameof(requestObj.City), requestObj.City, DbType.String);
                                parameters.Add(nameof(requestObj.PostalCode), requestObj.PostalCode, DbType.String);
                                parameters.Add("StateId", requestObj.State, DbType.String);
                            return parameters;
                        })
                },
                {
                    typeof(DeleteAddressByIdRequest), new SqlAndSqlParamsFuncMap<DeleteAddressByIdRequest>(AddressProcedures.DeleteById, requestObj => new { requestObj.Id })
                }
            };
        }
    }
}