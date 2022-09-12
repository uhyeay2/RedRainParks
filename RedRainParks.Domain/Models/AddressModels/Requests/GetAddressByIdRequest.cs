using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class GetAddressByIdRequest : GetByIdRequest
    {
        public GetAddressByIdRequest() { }

        public GetAddressByIdRequest(int id) : base(id) { }
    }
}