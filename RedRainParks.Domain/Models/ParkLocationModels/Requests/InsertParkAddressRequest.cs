using RedRainParks.Domain.Attributes;
using RedRainParks.Domain.Attributes.ClassAttributes;
using RedRainParks.Domain.Attributes.PropertyAttributes;
using RedRainParks.Domain.Models.BaseModels.BaseRequests;

namespace RedRainParks.Domain.Models.ParkLocationModels.Requests
{
    [InsertQuery("Address")]
    [InsertQuery("ParkLocationAddress", "ParkLocation", where: "ParkLocation.ParkCode = @ParkCode")]
    public class InsertParkAddressRequest : StringBasedRequest
    {
        public InsertParkAddressRequest(string parkCode, string referenceName, bool isActive, int rank, Guid addressGuid, string line1, string line2, string city, int stateId, string postalCode)
        {
            ParkCode = parkCode;
            ReferenceName = referenceName;
            IsActive = isActive;
            Rank = rank;
            AddressGuid = addressGuid;
            Line1 = line1;
            Line2 = line2;
            City = city;
            StateId = stateId;
            PostalCode = postalCode;
        }



        /// <summary>
        /// ParkCode for the ParkLocation that we are inserting an address for.
        /// </summary>
        public string ParkCode { get; set; }

        #region Insert Into Address 

        [Insertable("Address", specifiedColumnName: "Guid")]
        public Guid AddressGuid { get; set; }

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

        #endregion

        #region Insert Into ParkLocationAddress

        [Insertable("ParkLocationAddress", "ParkLocationId", "ParkLocation.Id")]
        public int? ParkLocationId { get; set; } = null;

        [Insertable("ParkLocationAddress", "AddressId", useScopedIdentity: true, sqlTypeName: "INT")]
        public int? AddressId { get; set; }

        [Insertable("ParkLocationAddress")]
        public string ReferenceName { get; set; }

        [Insertable("ParkLocationAddress")]
        public bool IsActive { get; set; } = true;

        [Insertable("ParkLocationAddress")]
        public int Rank { get; set; } = 1;

        #endregion

        public override bool IsValid(out string failedValidationMessage)
        {
            var isValid = base.IsValid(out failedValidationMessage);

            if(AddressGuid == Guid.Empty)
            {
                failedValidationMessage += " Invalid Request - AddressGuid must be provided";
                isValid = false;
            }

            return isValid;
        }

    }
}
