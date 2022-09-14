using RedRainParks.Domain.Constants;

namespace RedRainParks.Data.Procedures
{
    internal static class AddressProcedures
    {
        private static string _fromAddressJoinStateLookupOnStateId = "FROM Address WITH(NOLOCK) LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id";

        public static string GetById = $"SELECT {DTOProperties.Address} {_fromAddressJoinStateLookupOnStateId} WHERE Address.Id = @Id";

        public static string GetByGuid = $"SELECT {DTOProperties.Address} {_fromAddressJoinStateLookupOnStateId} WHERE Address.Guid = @Guid";

        public const string Insert = "PROC_INSERT_Address";
    }
}
