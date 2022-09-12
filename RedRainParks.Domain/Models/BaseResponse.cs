namespace RedRainParks.Domain.Models
{
    public abstract class BaseResponse
    {
        public int StatusCode { get; set; }

        public bool IsException { get; set; }
    }
}