using DataRequestMediator.Handlers.ParkLocationHandlers;
using Microsoft.AspNetCore.Mvc;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkLocationController
    {
        private readonly IMediator _mediator;

        public ParkLocationController(IMediator mediator) => _mediator = mediator;

        [HttpGet("getLocationByParkCode")]
        public async Task<IResponse> GetLocationByParkCode(string parkCode) => await _mediator.Send(new GetParkLocationByParkCodeRequest(parkCode));

        [HttpGet("getAddressByParkCode")]
        public async Task<IResponse> GetAddressByParkCode(string parkCode) => await _mediator.Send(new GetParkAddressByParkCodeRequest(parkCode));

        [HttpPost("insertParkLocation")]
        public async Task<IResponse> InsertParkLocation(InsertParkLocationRequest request) => await _mediator.Send(request);

        [HttpPost("insertParkAddress")]
        public async Task<IResponse> InsertParkAddress(InsertParkAddressRequest request) => await _mediator.Send(request);
    }
}
