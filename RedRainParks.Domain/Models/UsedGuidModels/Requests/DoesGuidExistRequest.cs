using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.UsedGuidModels.Requests
{
    public class DoesGuidExistRequest : GuidBasedRequest
    {
        public DoesGuidExistRequest(string guid) : base(guid) { }

        public DoesGuidExistRequest(Guid? guid) : base(guid) { }
    }
}
