namespace DataRequestMediator.Responses
{
    public interface IResponse
    {
        public int StatusCode { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public interface IResponse<TContent> : IResponse
    {
        TContent? Content { get; set; }
    }

}
