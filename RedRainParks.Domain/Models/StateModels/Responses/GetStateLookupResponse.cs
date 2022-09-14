using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Models.StateModels.Responses
{
    public class GetStateLookupResponse : BaseResponse
    {
        public StateLookupDTO? State { get; set; }
        public GetStateLookupResponse(StateLookupDTO? state)
        {
            if(state == null)
            {
                StatusCode = Domain.Constants.StatusCodes.NotFound_404;
                return;
            }
            State = state;
        }
    }
}
