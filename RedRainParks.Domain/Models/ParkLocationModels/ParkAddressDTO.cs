using RedRainParks.Domain.Attributes.ClassAttributes;
using RedRainParks.Domain.Attributes.PropertyAttributes;

namespace RedRainParks.Domain.Models.ParkLocationModels
{
    [FetchQuery(
        table: "ParkLocation WITH(NOLOCK)",
        join:   "LEFT JOIN ParkLocationAddress WITH(NOLOCK) ON ParkLocationAddress.ParkLocationId = ParkLocation.Id " +
                "LEFT JOIN Address WITH(NOLOCK) ON ParkLocationAddress.AddressId = Address.Id " +
                "LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id",        
        // Get All Addresses for a Park Location by Id or ParkCode
        where: "(ParkLocation.Id = @Id OR @Id IS NULL) AND (ParkLocation.ParkCode = @ParkCode OR @ParkCode IS NULL)" 
    )]
    public class ParkAddressDTO
    {
        #region ParkLocationAddress 

        [Fetchable("ParkLocationAddress.Id")]
        public long ParkAddressId { get; set; }

        [Fetchable()]
        public string? ReferenceName { get; set; } = string.Empty;

        [Fetchable]
        public int Rank { get; set; }

        [Fetchable("ParkLocationAddress.IsActive")]
        public bool IsActive { get; set; }

        #endregion

        #region ParkLocation

        [Fetchable("ParkLocation.Id")]
        public int ParkId { get; set; }

        [Fetchable("ParkLocation.Guid")]
        public Guid ParkGuid { get; set; }

        [Fetchable("ParkLocation.Name")]
        public string? Name { get; set; }

        [Fetchable]
		public string? ParkCode { get; set; }

        #endregion

        #region Address

        [Fetchable("Address.Id")]
        public long AddressId { get; set; }

        [Fetchable("Address.Guid")]
        public Guid AddressGuid { get; set; }

        [Fetchable]
        public string? Line1 { get; set; }

        [Fetchable]
        public string? Line2 { get; set; }

        [Fetchable]
        public string? City { get; set; }

        [Fetchable("Address.CreatedAtDateInUTC")]
        public DateTime CreatedAtDateInUTC { get; set; }
        
        [Fetchable("Address.LastUpdatedDateInUTC")]
        public DateTime LastUpdatedDateInUTC { get; set; }

        #endregion

        #region StateLookup

        [Fetchable("StateLookup.Abbreviation")]
        public string? State { get; set; }

        #endregion
    }
}
