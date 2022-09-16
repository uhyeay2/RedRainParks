using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.UsedGuidModels.Requests
{
    public class DeleteGuidRequest : GuidBasedRequest
    {
        public DeleteGuidRequest(string guid) : base(guid) { }

        public DeleteGuidRequest(Guid? guid) : base(guid) { }
    }
}
