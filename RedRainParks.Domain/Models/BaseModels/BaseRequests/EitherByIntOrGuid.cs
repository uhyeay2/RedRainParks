using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseModels.BaseRequests
{
    public class EitherByIntOrGuid : Either<int?, Guid?>, IValidatable
    {

        public EitherByIntOrGuid(int? left) : base(left)
        {
        }

        public EitherByIntOrGuid(Guid? right) : base(right)
        {
        }

        public EitherByIntOrGuid(string right) : base(Guid.TryParse(right, out var guid) ? guid : Guid.Empty)
        {
        }

        public bool IsValid(out string failedValidationMessage)
        {
            switch (this)
            {
                case var x when x.Left.GetValueOrDefault() <= 0 && x.Right.IsNullOrEmpty():
                    failedValidationMessage = $"Invalid Request! Must provide Either a valid number or Guid. Received: '{x.Left}' and '{x.Right}'";
                    return false;
                case var x when x.IsLeft && x.Left.GetValueOrDefault() <= 0:
                    failedValidationMessage = $"Invalid Request! The number provided must be greater than 0. Received: {x.Left}";
                    return false;
                case var x when !x.IsLeft && x.Right.IsNullOrEmpty():
                    failedValidationMessage = $"Invalid request! the Guid provided must be a proper guid that is not null or empty. Received: {x.Right}";
                    return false;
                default:
                    failedValidationMessage = string.Empty;
                    return true;
            }
        }
    }
}
