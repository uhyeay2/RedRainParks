using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.UsedGuidModels.Requests
{
    public class InsertGuidRequest : GuidBasedRequest
    {
        public InsertGuidRequest(string guid) : base(guid) { }

        public InsertGuidRequest(Guid? guid) : base(guid) { }
    }
}
