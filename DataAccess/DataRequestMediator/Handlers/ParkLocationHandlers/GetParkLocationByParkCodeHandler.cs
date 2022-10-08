using DataRequestHandler.Models.Requests.ParkLocation;

namespace DataRequestMediator.Handlers.ParkLocationHandlers
{
    public record GetParkLocationByParkCodeRequest(string ParkCode) : IRequest<IResponse>;

    internal class GetParkLocationByParkCodeHandler : IRequestHandler<GetParkLocationByParkCodeRequest, IResponse>
    {
        private readonly IDataHandler _dataHandler;

        public GetParkLocationByParkCodeHandler(IDataHandler dataHandler) => _dataHandler = dataHandler;

        public async Task<IResponse> Handle(GetParkLocationByParkCodeRequest request, CancellationToken cancellationToken)
        {
            var dto = await _dataHandler.FetchAsync<GetParkLocationByIdOrParkCode, ParkLocationDTO>(new(request.ParkCode));

            if(dto == null) return Response.NotFound("No Park Location was found with the park code: " + request.ParkCode);

            return Response.SuccessWithContent(dto);
        }
    }
}
