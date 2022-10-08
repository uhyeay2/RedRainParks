namespace DataRequestMediator.Responses
{
    public class BaseResponse : IResponse
    {
        public BaseResponse() { }

        public BaseResponse(int statusCode, bool success, string message)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
        }

        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class BaseResponse<TContent> :BaseResponse, IResponse<TContent>
    {
        public BaseResponse() { }

        public BaseResponse(int statusCode, bool success, string message, TContent content) : base(statusCode, success, message)
        {
            Content = content;
        }

        public TContent? Content { get; set; }
    }

    public static class Response
    {
        public static BaseResponse Success => new(statusCode: 200, success: true, message: "Success");

        public static BaseResponse<TContent> SuccessWithContent<TContent>(TContent content) => new(statusCode: 200, success: true, message: "Success", content);

        public static BaseResponse NotFound(string message) => new(statusCode: 404, success: false, message);

        public static BaseResponse AlreadyExists(string message) => new(statusCode: 403, success: false, message);

        public static BaseResponse BadRequest(string message) => new(statusCode: 400, success: false, message);

        public static BaseResponse UnExpected(string message = "An Unexpected Issue Occurred") => new(statusCode: 500, success: false, message);
    }
}
