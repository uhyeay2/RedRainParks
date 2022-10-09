using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record InsertAddressRequest(Guid Guid, string Line1, string Line2, string City, int StateId, string PostalCode) : IRequest<IResponse>;

    internal class InsertAddressHandler : BaseRequestHandler, IRequestHandler<InsertAddressRequest, IResponse>
    {
        public InsertAddressHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(InsertAddressRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(_mapper.Map<InsertAddress>(request));

            if (rowsAffected == 1) return Response.Success;

            return Response.UnExpected();
        }
    }
}
