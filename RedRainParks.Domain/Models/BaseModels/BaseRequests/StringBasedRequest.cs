using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseModels.BaseRequests
{
    public class StringBasedRequest : IValidatable
    {
        public string? RequestString { get; set; }

        public virtual bool IsValid(out string failedValidationMessage)
        {
            if(string.IsNullOrWhiteSpace(RequestString))
            {
                failedValidationMessage = "RequestString cannot be null or empty!";
                return false;
            }
            failedValidationMessage = string.Empty;
            return true;
        }
    }
}
