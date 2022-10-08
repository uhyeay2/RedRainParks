using DataRequestHandler.Models.Requests.ParkLocation;

namespace DataRequestMediator.Handlers.ParkLocationHandlers
{
    public record InsertParkLocationRequest(Guid Guid, string ParkCode, string Name, bool IsActive) : IRequest<IResponse>;

    internal class InsertParkLocationHandler : IRequestHandler<InsertParkLocationRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public InsertParkLocationHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(InsertParkLocationRequest request, CancellationToken cancellationToken)
        {
            var affectedRows = await _dataHandler.ExecuteAsync(new InsertParkLocation(request.Guid, request.ParkCode, request.Name, request.IsActive));
            
            if (affectedRows == 1) return Response.Success;

            return Response.UnExpected("Expected to insert one row - Rows Inserted: " + affectedRows);
        }
    }
}
