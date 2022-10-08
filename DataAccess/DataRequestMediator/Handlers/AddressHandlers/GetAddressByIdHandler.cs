using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record GetAddressByIdRequest(long Id) : IRequest<IResponse<Address>>;

    internal class GetAddressByIdHandler : IRequestHandler<GetAddressByIdRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public GetAddressByIdHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public async Task<IResponse> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchAsync<GetAddressById, AddressDTO>(new(request.Id));

            if(dto == null) return Response.NotFound("No Address found with Id: " + request.Id);

            return Response.SuccessWithContent<Address>(new(dto.Guid, dto.Line1 ?? string.Empty, dto.Line2 ?? string.Empty, dto.City ?? string.Empty,
                dto.StateAbbreviation ?? string.Empty, dto.PostalCode ?? string.Empty));
        }
    }
}
