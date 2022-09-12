namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class InsertAddressRequest
    {
        public Guid Guid { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }
        
        public string PostalCode { get; set; }

        public InsertAddressRequest(Guid guid, string line1, string line2, string city, int stateId, string postalCode)
        {
            Guid = guid;
            Line1 = line1;
            Line2 = line2;
            City = city;
            StateId = stateId;
            PostalCode = postalCode;
        }
    }
}
