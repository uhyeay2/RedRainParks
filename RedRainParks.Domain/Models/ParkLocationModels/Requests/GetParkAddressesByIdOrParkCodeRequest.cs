using RedRainParks.Domain.Models.BaseModels.BaseRequests;

namespace RedRainParks.Domain.Models.ParkLocationModels.Requests
{
    public class GetParkAddressesByIdOrParkCodeRequest : EitherByIntOrString
    {
        public GetParkAddressesByIdOrParkCodeRequest(int? left) : base(left)
        {
        }
        public GetParkAddressesByIdOrParkCodeRequest(string? right) : base(right)
        {
        }
    }
}
