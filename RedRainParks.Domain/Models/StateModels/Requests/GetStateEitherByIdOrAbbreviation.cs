using RedRainParks.Domain.Models.BaseModels.BaseRequests;

namespace RedRainParks.Domain.Models.StateModels.Requests
{
    public class GetStateEitherByIdOrAbbreviation : EitherByIntOrString
    {
        public GetStateEitherByIdOrAbbreviation(int? left) : base(left)
        {
        }

        public GetStateEitherByIdOrAbbreviation(string? right) : base(right)
        {
        }
    }
}
