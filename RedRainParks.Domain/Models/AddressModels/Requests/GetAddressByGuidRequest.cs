using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class GetAddressByGuidRequest : GuidBasedRequest
    {
        public GetAddressByGuidRequest()
        {
        }

        public GetAddressByGuidRequest(string guid) : base(guid)
        {
        }

        public GetAddressByGuidRequest(Guid? guid) : base(guid)
        {
        }
    }
}
