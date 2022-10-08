using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record DeleteAddressByIdRequest(long Id) : IRequest<IResponse>;

    internal class DeleteAddressByIdHandler : IRequestHandler<DeleteAddressByIdRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public DeleteAddressByIdHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(DeleteAddressByIdRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(new DeleteAddressById(request.Id));

            if (rowsAffected == 1) return Response.Success;

            return Response.NotFound("No Address was found with the Id: " + request.Id);
        }
    }
}
