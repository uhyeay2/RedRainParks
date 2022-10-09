using DataRequestHandler.Models.Requests.StateLookup;

namespace DataRequestMediator.Handlers.StateLookupHandlers
{
    public record GetStateByIdOrAbbreviationRequest(string Identifier) : IRequest<IResponse>;

    internal class GetStateByIdOrAbbreviationHandler : BaseRequestHandler, IRequestHandler<GetStateByIdOrAbbreviationRequest, IResponse>
    {
        public GetStateByIdOrAbbreviationHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(GetStateByIdOrAbbreviationRequest request, CancellationToken cancellationToken)
        {
            GetStateByIdOrAbbreviation r = int.TryParse(request.Identifier, out var id) ? new(id) : new(request.Identifier);

            var dto = await _dataHandler.FetchAsync<GetStateByIdOrAbbreviation, StateLookupDTO>(r);

            if (dto == null) return Response.NotFound("No State was found with the identifier: " + request.Identifier);

            return Response.SuccessWithContent(_mapper.Map<StateLookup>(dto));
        }
    }
}
