using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Models.LoggingModels.Requests
{
    public class InsertExceptionLogRequest
    {
        [Insertable]
		public string? CreatedBy { get; set; }
        
        [Insertable]
		public string? RequestHeaders { get; set; }
        
        [Insertable]
		public string? RequestBody { get; set; }
        
        [Insertable]
		public string? Message { get; set; }
        
        [Insertable]
		public string? Source { get; set; }

        [Insertable]
		public string? StackTrace { get; set; }

        public InsertExceptionLogRequest(string? createdBy, string? requestHeaders, string? requestBody, string? message, string? source, string? stackTrace)
        {
            CreatedBy = createdBy;
            RequestHeaders = requestHeaders;
            RequestBody = requestBody;
            Message = message;
            Source = source;
            StackTrace = stackTrace;
        }
    }
}
