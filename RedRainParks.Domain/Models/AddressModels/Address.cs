using RedRainParks.Domain.Models.AddressModels.DataTransferObjects;

namespace RedRainParks.Domain.Models.AddressModels
{
    public class Address
    {
        public string StreetLine1 { get; set; } = string.Empty;

        public string StreetLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int State { get; set; }

        public string PostalCode { get; set; } = string.Empty;

        public Address() { }

        public Address(string streetLine1, string streetLine2, string city, int state, string postalCode)
        {
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            PostalCode = postalCode;
            City = city;
            State = state;
        }

        public Address(AddressDTO address)
        {
            StreetLine1 = address.Line1 ?? String.Empty;
            StreetLine2 = address.Line2 ?? String.Empty;
            City = address.City ?? String.Empty;
            State = address.State.GetValueOrDefault();
            PostalCode = address.PostalCode ?? String.Empty;
        }

    }
}
