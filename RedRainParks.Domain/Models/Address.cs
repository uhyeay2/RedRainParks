namespace RedRainParks.Domain.Models
{
    public class Address
    {
        public Address() { }

        public Address(Guid guid, string streetLine1, string streetLine2, string city, StateLookup state, string postalCode)
        {
            Guid = guid;
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            PostalCode = postalCode;
            City = city;
            State = state;
        }
        
        public Guid Guid { get; set; }

        public string StreetLine1 { get; set; } = string.Empty;

        public string StreetLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public StateLookup State { get; set; } = new();

        public string PostalCode { get; set; } = string.Empty;
    }
}
