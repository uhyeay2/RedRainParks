using DataRequestHandler.Models.Requests.Address;

namespace DataRequestMediator.Handlers.AddressHandlers
{
    public record UpdateAddressRequest(Guid Guid, string Line1, string Line2, string City, int StateId, string PostalCode) : IRequest<IResponse>;

    internal class UpdateAddressHandler : BaseRequestHandler, IRequestHandler<UpdateAddressRequest, IResponse>
    {
        public UpdateAddressHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        public async Task<IResponse> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _dataHandler.ExecuteAsync(_mapper.Map<UpdateAddress>(request));

            if (rowsAffected == 1) return Response.Success;

            return Response.NotFound("No Address was found with the Guid: " + request.Guid);
        }
    }   
}
