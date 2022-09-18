using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class InsertAddressRequest : GuidBasedRequest
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }
        
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
