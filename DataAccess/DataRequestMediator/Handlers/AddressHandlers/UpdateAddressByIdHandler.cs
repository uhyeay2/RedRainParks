using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record UpdateAddressRequest(long Id, string Line1, string Line2, string City, int StateId, string PostalCode) : IRequest<IResponse>;

    internal class UpdateAddressByIdHandler : IRequestHandler<UpdateAddressRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public UpdateAddressByIdHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(new UpdateAddressById(request.Id, request.Line1, request.Line2, request.City, request.StateId, request.PostalCode));

            if (rowsAffected == 1) return Response.Success;

            return Response.NotFound("No Address was found with the Id: " + request.Id);
        }
    }
}
