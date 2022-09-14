using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseRequests
{
    public abstract class GetByGuidRequest : IValidatable
    {
        public Guid? Guid { get; set; }

        public GetByGuidRequest() { }

        public GetByGuidRequest(string guid)
        {
            Guid = System.Guid.TryParse(guid, out var g) ? g : System.Guid.Empty;
        }

        public GetByGuidRequest(Guid? guid)
        {
            Guid = guid;
        }

        public bool IsValid(out string failedValidationMessage)
        {
            if (Guid == null || Guid == System.Guid.Empty)
            {
                failedValidationMessage = $"Invalid Guid Received! Guid: {Guid}";
                return false;
            }
            failedValidationMessage = string.Empty;
            return true;
        }
    }
}
