using DataRequestHandler.Models.Requests.StateLookup;

namespace DataRequestMediator.Handlers.StateLookupHandlers
{
    public record GetAllStatesRequest() : IRequest<IResponse>;

    internal class GetAllStatesHandler : IRequestHandler<GetAllStatesRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public GetAllStatesHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(GetAllStatesRequest request, CancellationToken cancellationToken) =>
            Response.SuccessWithContent(await _dataHandler.FetchListAsync<GetAllStates, StateLookupDTO>(new()));
    }
}
