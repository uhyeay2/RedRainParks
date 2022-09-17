using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseRequests
{
    public abstract class GuidBasedRequest : IValidatable
    {
        public Guid? Guid { get; set; }

        public GuidBasedRequest() { }

        public GuidBasedRequest(string guid)
        {
            Guid = System.Guid.TryParse(guid, out var g) ? g : System.Guid.Empty;
        }

        public GuidBasedRequest(Guid? guid)
        {
            Guid = guid;
        }

        public virtual bool IsValid(out string failedValidationMessage)
        {
            if (Guid.IsNullOrEmpty())
            {
                failedValidationMessage = $"Invalid Guid Received! Guid: {Guid}";
                return false;
            }
            failedValidationMessage = string.Empty;
            return true;
        }
    }
}
