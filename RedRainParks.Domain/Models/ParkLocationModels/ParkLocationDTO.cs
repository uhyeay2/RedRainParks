using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Models.ParkLocationModels
{
    public class ParkLocationDTO
    {
        #region ParkLocation

        [Fetchable("ParkLocation.Id")]
        public int Id { get; set; }

        [Fetchable("ParkLocation.Guid")]
        public Guid Guid { get; set; }

        [Fetchable]
        public string? ParkCode { get; set; }

        [Fetchable]
        public string? Name { get; set; }

        [Fetchable("ParkLocation.IsActive")]
        public bool IsActive { get; set; }

        [Fetchable("ParkLocation.CreatedAtDateInUTC")]
        public DateTime CreatedAtDateInUTC { get; set; }

        [Fetchable("ParkLocation.LastUpdatedDateInUTC")]
        public DateTime LastUpdatedDateInUTC { get; set; }

        #endregion

        #region Main Address (First After Ordering By Rank)

        [Fetchable("Address.Id")]
        public long MainAddressId { get; set; }

        [Fetchable("Address.Guid")]
        public Guid MainAddressGuid { get; set; }

        [Fetchable("Address.Line1")]
        public string? MainAddressLine1 { get; set; }

        [Fetchable("Address.Line2")]
        public string? MainAddressLine2 { get; set; }

        [Fetchable("Address.City")]
        public string? MainAddressCity { get; set; }

        [Fetchable("StateLookup.Abbreviation")]
        public string? State { get; set; }

        #endregion

    }
}
