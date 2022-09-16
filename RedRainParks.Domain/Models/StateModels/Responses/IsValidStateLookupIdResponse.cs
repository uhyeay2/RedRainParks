using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Models.StateModels.Responses
{
    public class IsValidStateLookupIdResponse : BaseResponse
    {
        public bool IsValid { get; set; }

        public IsValidStateLookupIdResponse(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
