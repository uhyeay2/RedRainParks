namespace RedRainParks.Domain.Models.BaseModels
{
    public class ExecutionResponse : BaseResponse
    {
        public int RowsChanged { get; set; }

        public ExecutionResponse(int rowsChanged) : base()
        {
            RowsChanged = rowsChanged;
        }

        public ExecutionResponse(int statusCode, string? exceptionMessage, bool isException = true) : base(statusCode, exceptionMessage, isException)
        {
        }
    }
}
