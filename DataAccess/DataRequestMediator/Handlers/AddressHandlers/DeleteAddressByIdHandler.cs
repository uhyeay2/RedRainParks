using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record DeleteAddressByIdRequest(long Id) : IRequest<IResponse>;

    internal class DeleteAddressByIdHandler : BaseRequestHandler, IRequestHandler<DeleteAddressByIdRequest, IResponse>
    {
        public DeleteAddressByIdHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(DeleteAddressByIdRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(_mapper.Map<DeleteAddressById>(request));

            if (rowsAffected == 1) return Response.Success;

            return Response.NotFound("No Address was found with the Id: " + request.Id);
        }
    }
}
