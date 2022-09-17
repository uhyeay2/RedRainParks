using RedRainParks.Data.Attributes;
using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class UpdateAddressByIdRequest : LongIdBasedRequest
    {
        public UpdateAddressByIdRequest(long id, string? line1, string? line2, string? city, int? state, string? postalCode) : base(id)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

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

        public override bool IsValid(out string failedValidationMessage)
        {
            var isValid = base.IsValid(out failedValidationMessage);

            if(Line1 != null && string.IsNullOrWhiteSpace(Line1))
            {
                isValid = false;
                failedValidationMessage += " Invalid Request - Address Line 1 field cannot be empty!";
            }

            if (City != null && string.IsNullOrWhiteSpace(City))
            {
                isValid = false;
                failedValidationMessage += " Invalid Request - City field cannot be empty!";
            }

            return isValid;
        }
    }
}
