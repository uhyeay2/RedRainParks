using RedRainParks.Domain.Models.BaseModels.BaseRequests;

namespace RedRainParks.Domain.Models.ParkLocationModels.Requests
{
    public class GetParkLocationByIdOrParkCodeRequest : EitherByIntOrString
    {
        public GetParkLocationByIdOrParkCodeRequest(int? left) : base(left)
        {
        }
        public GetParkLocationByIdOrParkCodeRequest(string? right) : base(right)
        {
        }
    }
}
