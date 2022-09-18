using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.ParkLocationModels;
using RedRainParks.Domain.Models.ParkLocationModels.Requests;

namespace RedRainParks.Data.Procedures
{
    internal static class ParkLocationProperties
    {
        internal static readonly (string DatabaseName, string PropertyName)[] FetchAddress = typeof(ParkAddressDTO).GetSqlPropertyNames();

        internal static readonly (string DatabaseName, string PropertyName)[] InsertLocation = typeof(InsertParkLocationRequest).GetSqlPropertyNames();
    }

    public static class ParkLocationProcedures
    {
        private const string _fromParkLocation_JoinAddressAndState_ThroughParkLocationAddress = @"FROM ParkLocation WITH(NOLOCK) 
            JOIN ParkLocationAddress WITH(NOLOCK) ON ParkLocationAddress.ParkLocationId = ParkLocation.Id 
                JOIN Address WITH(NOLOCK) ON ParkLocationAddress.AddressId = Address.Id
                    JOIN StateLookup WITH(NOLOCK) ON Address.StateId = State.Id";

        public static readonly string GetParkAddressesByIdOrParkCode = SharedSql.Select(ParkLocationProperties.FetchAddress) + 
            _fromParkLocation_JoinAddressAndState_ThroughParkLocationAddress + SharedSql.WhereEither("ParkLocation.Id", "Id", "ParkLocation.ParkCode", "ParkCode");

        public static readonly string InsertParkLocation = SharedSql.Insert("ParkLocation", ParkLocationProperties.InsertLocation);

        public static readonly string DeleteParkLocationById = SharedSql.Delete("ParkLocation", "Id = @Id");
    }
}
