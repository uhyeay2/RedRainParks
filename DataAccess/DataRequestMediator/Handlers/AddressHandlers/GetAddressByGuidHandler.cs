using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record GetAddressByGuidRequest(Guid Guid) : IRequest<IResponse>;

    internal class GetAddressByGuidHandler : BaseRequestHandler, IRequestHandler<GetAddressByGuidRequest, IResponse>
    {
        public GetAddressByGuidHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(GetAddressByGuidRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchAsync<GetAddressByGuid, AddressDTO>(_mapper.Map<GetAddressByGuid>(request));

            if(dto == null) return Response.NotFound("No Address found with Guid: " + request.Guid);

            return Response.SuccessWithContent(_mapper.Map<Address>(dto));
        }
    }  
}
