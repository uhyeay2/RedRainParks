using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.ParkLocationModels;
using RedRainParks.Domain.Models.ParkLocationModels.Requests;

namespace RedRainParks.Data.Procedures
{
    internal static class ParkLocationProperties
    {
        internal static readonly (string DatabaseName, string PropertyName)[] GetAddress = typeof(ParkAddressDTO).GetSqlPropertyNames();

        internal static readonly (string DatabaseName, string PropertyName)[] GetLocation = typeof(ParkLocationDTO).GetSqlPropertyNames();

        internal static readonly (string DatabaseName, string PropertyName)[] InsertLocation = typeof(InsertParkLocationRequest).GetSqlPropertyNames();
    }

    public static class ParkLocationProcedures
    {
        private const string _fromParkLocation_JoinAddressAndState_ThroughParkLocationAddress = @"FROM ParkLocation WITH(NOLOCK) 
            LEFT JOIN ParkLocationAddress WITH(NOLOCK) ON ParkLocationAddress.ParkLocationId = ParkLocation.Id 
                LEFT JOIN Address WITH(NOLOCK) ON ParkLocationAddress.AddressId = Address.Id
                    LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id ";

        public static readonly string GetAddressesByIdOrParkCode = SharedSql.Select(ParkLocationProperties.GetAddress,
            _fromParkLocation_JoinAddressAndState_ThroughParkLocationAddress, SharedSql.WhereEither("ParkLocation.Id", "@Id", "ParkLocation.ParkCode", "@ParkCode"));

        public static readonly string GetLocationByIdOrParkCode = 
            SharedSql.Select(ParkLocationProperties.GetLocation, _fromParkLocation_JoinAddressAndState_ThroughParkLocationAddress, 
                SharedSql.WhereEither("ParkLocation.Id", "@Id", "ParkLocation.ParkCode", "@ParkCode"), "ORDER BY ParkLocationAddress.Rank");

        public static readonly string InsertParkLocation = SharedSql.Insert("ParkLocation", ParkLocationProperties.InsertLocation);

        public static readonly string DeleteParkLocationById = SharedSql.Delete("ParkLocation", "Id = @Id");
    }
}
