using RedRainParks.Domain.Attributes.SQLGeneration.InsertAttributes;
using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    [InsertQuery("Address")]
    public class InsertAddressRequest : GuidBasedRequest
    {

        [Insertable("Address")]
        public override Guid? Guid { get; set; }

        [Insertable("Address")]
        public string Line1 { get; set; }

        [Insertable("Address")]
        public string Line2 { get; set; }

        [Insertable("Address")]
        public string City { get; set; }

        [Insertable("Address")]
        public int StateId { get; set; }
        
        [Insertable("Address")]
        public string PostalCode { get; set; }

        public InsertAddressRequest(Guid guid, string line1, string line2, string city, int stateId, string postalCode) : base(guid)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            StateId = stateId;
            PostalCode = postalCode;
        }

        public InsertAddressRequest(string guid, string line1, string line2, string city, int stateId, string postalCode) : base(guid)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            StateId = stateId;
            PostalCode = postalCode;
        }
    }
}
