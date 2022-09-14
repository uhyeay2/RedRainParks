using RedRainParks.Domain.Enums;
using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Models.AddressModels.Responses
{
    public class GetAddressByGuidResponse : BaseResponse
    {
        public Address? Address { get; set; }

        public GetAddressByGuidResponse(AddressDTO? address, string stateDisplay) : base()
        {
            if(address == null)
            {
                StatusCode = Constants.StatusCodes.NotFound_404;
                return;
            }
            Address = new Address(address, stateDisplay.GetDisplayOrDefault());
        }
    }
}
