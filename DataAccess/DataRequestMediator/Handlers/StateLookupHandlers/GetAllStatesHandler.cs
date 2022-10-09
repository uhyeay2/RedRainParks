using DataRequestHandler.Models.Requests.StateLookup;

namespace DataRequestMediator.Handlers.StateLookupHandlers
{
    public record GetAllStatesRequest() : IRequest<IResponse>;

    internal class GetAllStatesHandler : BaseRequestHandler, IRequestHandler<GetAllStatesRequest, IResponse>
    {
        public GetAllStatesHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(GetAllStatesRequest request, CancellationToken cancellationToken) =>
            Response.SuccessWithContent(_mapper.Map<IEnumerable<StateLookup>>(
                await _dataHandler.FetchListAsync<GetAllStates, StateLookupDTO>(new())));
    }
}
