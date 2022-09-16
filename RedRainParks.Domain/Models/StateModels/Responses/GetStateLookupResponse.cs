using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Models.StateModels.Responses
{
    public class GetStateLookupResponse : BaseResponse
    {
        public StateLookup? State { get; set; }
        public GetStateLookupResponse(StateLookupDTO? state)
        {
            if(state == null)
            {
                StatusCode = Constants.StatusCodes.NotFound_404;
                return;
            }
            State = new(state);
        }

        public GetStateLookupResponse(int statusCode, string failedValidationMessage) : base(statusCode, failedValidationMessage)
        {
        }
    }
}
