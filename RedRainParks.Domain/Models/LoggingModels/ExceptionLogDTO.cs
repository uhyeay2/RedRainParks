using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRainParks.Domain.Models.LoggingModels
{
    internal class ExceptionLogDTO
    {
		public long Id { get; set; }
		public DateTime CreatedAtDateInUTC { get; set; }
		public string? CreatedBy { get; set; }
		public string? RequestHeaders { get; set; }
		public string? RequestBody { get; set; }
		public string? Message { get; set; }
		public string? Source { get; set; }
		public string? StackTrace { get; set; }

        public ExceptionLogDTO(long id, DateTime createdAtDateInUTC, string? createdBy, string? requestHeaders, string? requestBody, string? message, string? source, string? stackTrace)
        {
            Id = id;
            CreatedAtDateInUTC = createdAtDateInUTC;
            CreatedBy = createdBy;
            RequestHeaders = requestHeaders;
            RequestBody = requestBody;
            Message = message;
            Source = source;
            StackTrace = stackTrace;
        }
    }
}
