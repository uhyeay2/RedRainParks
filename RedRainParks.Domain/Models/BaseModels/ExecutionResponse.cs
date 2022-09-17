namespace RedRainParks.Domain.Models.BaseModels
{
    public class ExecutionResponse : BaseResponse
    {
        public int RowsAffected { get; set; }

        public ExecutionResponse(int rowsAffected, bool statusCode404IfRowsAffectedIsZero = true) : base()
        {
            RowsAffected = rowsAffected;
            if (rowsAffected == 0 && statusCode404IfRowsAffectedIsZero)
                StatusCode = Constants.StatusCodes.NotFound_404;
        }

        public ExecutionResponse(int statusCode, string? exceptionMessage, bool isException = true) : base(statusCode, exceptionMessage, isException)
        {
        }
    }
}
