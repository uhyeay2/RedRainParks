namespace RedRainParks.Domain.Models.BaseModels
{
    public class ExecutionResponse : BaseResponse
    {
        public int RowsAffected { get; set; }

        public ExecutionResponse(int rowsAffected) : base()
        {
            RowsAffected = rowsAffected;
        }

        public ExecutionResponse(int statusCode, string? exceptionMessage, bool isException = true) : base(statusCode, exceptionMessage, isException)
        {
        }
    }
}
