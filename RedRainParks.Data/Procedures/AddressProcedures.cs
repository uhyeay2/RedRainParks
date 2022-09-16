using RedRainParks.Domain.Constants;

namespace RedRainParks.Data.Procedures
{
    internal static class AddressProcedures
    {
        private const string _fromAddressJoinStateLookupOnStateId = "FROM Address WITH(NOLOCK) LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id";

        public static readonly string GetById = $"SELECT {DTOProperties.Address} {_fromAddressJoinStateLookupOnStateId} WHERE Address.Id = @Id";

        public static readonly string GetByGuid = $"SELECT {DTOProperties.Address} {_fromAddressJoinStateLookupOnStateId} WHERE Address.Guid = @Guid";

        public static readonly string UpdateById = $"UPDATE Address SET {SharedSql.Coalesce(DTOProperties.AddressUpdateableFields)} WHERE Address.Id = @Id";

        public static readonly string DeleteById = $"DELETE FROM Address WHERE Id = @Id";

        public const string Insert = "PROC_INSERT_Address";
    }
}
