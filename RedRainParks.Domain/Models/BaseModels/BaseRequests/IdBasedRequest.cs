using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Domain.Models.BaseRequests
{
    public abstract class IdBasedRequest : IValidatable
    {
        public int Id { get; set; }

        public IdBasedRequest(int id)
        {
            Id = id;
        }

        public IdBasedRequest() { }

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

    public abstract class LongIdBasedRequest : IValidatable
    {
        public long Id { get; set; }

        public LongIdBasedRequest(long id)
        {
            Id = id;
        }

        public LongIdBasedRequest() { }

        public bool IsValid(out string failedValidationMessage)
        {
            if (Id <= 0)
            {
                failedValidationMessage = $"Invalid Id Received! Id must be greater than 0. Id: {Id}";
                return false;
            }
            failedValidationMessage = string.Empty;
            return true;
        }
    }
}
