using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseRequests
{
    public abstract class GetByIdRequest : IValidatable
    {
        public int Id { get; set; }

        public GetByIdRequest(int id)
        {
            Id = id;
        }

        public GetByIdRequest() { }

        public bool IsValid(out string failedValidationMessage)
        {
            if(Id <= 0)
            {
                failedValidationMessage = $"Invalid Id Received! Id must be greater than 0. Id: {Id}";
                return false;
            }
            failedValidationMessage = string.Empty;
            return true;
        }
    }
}
