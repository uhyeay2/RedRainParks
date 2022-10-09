using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record DeleteAddressRequest(Guid Guid) : IRequest<IResponse>;

    internal class DeleteAddressHandler : BaseRequestHandler, IRequestHandler<DeleteAddressRequest, IResponse>
    {
        public DeleteAddressHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(_mapper.Map<DeleteAddress>(request));

            if (rowsAffected == 1) return Response.Success;

            return Response.NotFound("No Address was found with the Guid: " + request.Guid);
        }
    }
}
