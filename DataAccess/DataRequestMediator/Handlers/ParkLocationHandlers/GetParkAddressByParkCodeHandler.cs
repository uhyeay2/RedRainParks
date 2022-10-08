using DataRequestHandler.Models.Requests.ParkLocation;

namespace DataRequestMediator.Handlers.ParkLocationHandlers
{
    public record GetParkAddressByParkCodeRequest(string ParkCode) : IRequest<IResponse>;

    internal class GetParkAddressByParkCodeHandler : IRequestHandler<GetParkAddressByParkCodeRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public GetParkAddressByParkCodeHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(GetParkAddressByParkCodeRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchListAsync<GetParkAddressByIdOrParkCode, ParkAddressDTO>(new(request.ParkCode));

            if (dto?.Any() ?? false) return Response.SuccessWithContent(dto);

            return Response.NotFound("No addresses were found with the park code: " + request.ParkCode);
        }
    }
}
