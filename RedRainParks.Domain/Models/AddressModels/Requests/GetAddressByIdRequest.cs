using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class GetAddressByIdRequest : LongIdBasedRequest
    {
        public GetAddressByIdRequest() { }

        public GetAddressByIdRequest(long id) : base(id) { }
    }
}