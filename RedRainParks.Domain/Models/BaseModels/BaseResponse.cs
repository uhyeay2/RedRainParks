namespace RedRainParks.Domain.Models.BaseModels
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }

        public bool IsException { get; set; } = false;

        public string ExceptionMessage { get; set; } = string.Empty;

        public BaseResponse(int statusCode)
        {
            StatusCode = statusCode;
        }

        public BaseResponse() : this(Constants.StatusCodes.OK_200)
        {
        }

        public BaseResponse(int statusCode, string? exceptionMessage, bool isException = true)
        {
            StatusCode = statusCode;
            ExceptionMessage = exceptionMessage ?? string.Empty;
            IsException = isException;
        }

    }
}