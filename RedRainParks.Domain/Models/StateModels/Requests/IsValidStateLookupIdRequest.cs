using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.StateModels.Requests
{
    public class IsValidStateLookupIdRequest : IdBasedRequest
    {
        public IsValidStateLookupIdRequest(int id) : base(id)
        {
        }
    }
}
