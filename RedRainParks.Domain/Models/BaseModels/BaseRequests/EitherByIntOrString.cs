using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseModels.BaseRequests
{
    public abstract class EitherByIntOrString : Either<int?, string?>, IValidatable
    {
        protected EitherByIntOrString(int? left) : base(left)
        {
        }

        protected EitherByIntOrString(string? right) : base(right)
        {
        }

        public bool IsValid(out string failedValidationMessage)
        {
            switch (this)
            {
                case var x when x.Left.GetValueOrDefault() <= 0 && string.IsNullOrWhiteSpace(x.Right):
                    failedValidationMessage = $"Invalid Request! Must provide Either a valid number or string. Received: '{x.Left}' and '{x.Right}'";
                    return false;
                case var x when x.IsLeft && x.Left.GetValueOrDefault() <= 0:
                    failedValidationMessage = "Invalid Request! The number provided must be greater than 0";
                    return false;
                case var x when !x.IsLeft && string.IsNullOrWhiteSpace(x.Right):
                    failedValidationMessage = "Invalid request! the string provided cannot be null or empty";
                    return false;
                default:
                    failedValidationMessage = string.Empty;
                    return true;
            }
        }
    }
}
