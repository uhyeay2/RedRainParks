using DataRequestHandler.Models.Requests.ParkLocation;
using DataRequestMediator.Handlers.AddressHandlers;

namespace DataRequestMediator.Handlers.ParkLocationHandlers
{
    public record InsertParkAddressRequest(string ParkCode, string ReferenceName, bool IsActive, int Rank, InsertAddressRequest Address) : IRequest<IResponse>;

    internal class InsertParkAddressHandler : IRequestHandler<InsertParkAddressRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public InsertParkAddressHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(InsertParkAddressRequest request, CancellationToken cancellationToken)
        {
            var affectedRows = await _dataHandler.ExecuteAsync(new InsertParkAddress(request.ParkCode, request.ReferenceName, request.IsActive, request.Rank,
                request.Address.Guid, request.Address.Line1, request.Address.Line2, request.Address.City, request.Address.StateId, request.Address.PostalCode));

            // Inserting Park Address should insert record into ParkLocationAddress and Address tables
            if (affectedRows == 2) return Response.Success;

            return Response.UnExpected("Expected to insert two rows - Rows Inserted: " + affectedRows);
        }
    }
}
