using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.Data.Procedures
{
    internal static class AddressProperties
    {
        internal static readonly (string DatabaseName, string PropertyName)[] GetAddress = typeof(AddressDTO).GetSqlPropertyNames();

        internal static readonly (string DatabaseName, string PropertyName)[] UpdateAddress = typeof(UpdateAddressByIdRequest).GetSqlPropertyNames();
    }

    internal static class AddressProcedures
    {
        private const string _fromAddressJoinStateLookupOnStateId = "FROM Address WITH(NOLOCK) LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id";

        public static readonly string GetById = SharedSql.Select(AddressProperties.GetAddress, _fromAddressJoinStateLookupOnStateId, "WHERE Address.Id = @Id");

        public static readonly string GetByGuid = SharedSql.Select(AddressProperties.GetAddress, _fromAddressJoinStateLookupOnStateId, "WHERE Address.Guid = @Guid");

        public static readonly string UpdateById = SharedSql.CoalesceUpdate("Address", AddressProperties.UpdateAddress, "Address.Id = @Id");

        public static readonly string DeleteById = SharedSql.Delete("Address", "Id = @Id");

        public const string Insert = "PROC_INSERT_Address";
    }
}
