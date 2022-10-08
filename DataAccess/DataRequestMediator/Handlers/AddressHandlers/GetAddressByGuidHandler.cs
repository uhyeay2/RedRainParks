using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record GetAddressByGuidRequest(Guid Guid) : IRequest<IResponse>;

    internal class GetAddressByGuidHandler : IRequestHandler<GetAddressByGuidRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public GetAddressByGuidHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(GetAddressByGuidRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchAsync<GetAddressByGuid, AddressDTO>(new(request.Guid));

            if(dto == null) return Response.NotFound("No Address found with Guid: " + request.Guid);

            return Response.SuccessWithContent<Address>(new(dto.Guid, dto.Line1 ?? string.Empty, dto.Line2 ?? string.Empty, dto.City ?? string.Empty,
                dto.StateAbbreviation ?? string.Empty, dto.PostalCode ?? string.Empty));
        }
    }
}
