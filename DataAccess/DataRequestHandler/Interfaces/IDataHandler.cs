namespace DataRequestHandler.Interfaces
{
    public interface IDataHandler
    {
        public Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject;

        public Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject;

        public Task<int> ExecuteAsync<TInput>(TInput request) where TInput : IRequestObject;
    }
}
