using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record GetAddressByIdRequest(long Id) : IRequest<IResponse<Address>>;

    internal class GetAddressByIdHandler : BaseRequestHandler, IRequestHandler<GetAddressByIdRequest, IResponse>
    {
        public GetAddressByIdHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchAsync<GetAddressById, AddressDTO>(_mapper.Map<GetAddressById>(request));

            if(dto == null) return Response.NotFound("No Address found with Id: " + request.Id);

            return Response.SuccessWithContent(_mapper.Map<Address>(dto));
        }
    }
}
