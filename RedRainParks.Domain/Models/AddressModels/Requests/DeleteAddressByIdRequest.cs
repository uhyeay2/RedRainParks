using RedRainParks.Domain.Models.BaseRequests;

namespace RedRainParks.Domain.Models.AddressModels.Requests
{
    public class DeleteAddressByIdRequest : LongIdBasedRequest
    {
        public DeleteAddressByIdRequest(long id) : base(id)
        {
        }
    }
}
