using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class GetAddressByGuidRequest : GetByGuidRequest
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

        public string Language { get; set; } = Enum.GetName(Enums.StateDisplay.English)!;

    }
}
