using RedRainParks.Data.Attributes;
using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class UpdateAddressByIdRequest : LongIdBasedRequest
    {
        [Updatable()]
        public string? Line1 { get; set; }

        [Updatable()]
        public string? Line2 { get; set; }

        [Updatable()]
        public string? City { get; set; }

        [Updatable("StateId")]
        public int? State { get; set; }

        [Updatable()]
        public string? PostalCode { get; set; }
    }
}
