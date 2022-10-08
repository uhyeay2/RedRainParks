using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record InsertAddressRequest(Guid Guid, string Line1, string Line2, string City, int StateId, string PostalCode) : IRequest<IResponse>;

    internal class InsertAddressHandler : IRequestHandler<InsertAddressRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public InsertAddressHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(InsertAddressRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(new InsertAddress(request.Guid, request.Line1, request.Line2, request.City, request.StateId, request.PostalCode));

            if (rowsAffected == 1) return Response.Success;

            return Response.UnExpected();
        }
    }
}
