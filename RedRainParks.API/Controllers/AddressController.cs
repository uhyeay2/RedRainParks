using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetByGuid")]
        public async Task<IResponse> GetByGuidAsync([FromHeader] Guid guid) => await _mediator.Send(new GetAddressByGuidRequest(guid));

        [HttpGet("GetById")]
        public async Task<IResponse> GetByIdAsync(long id) => await _mediator.Send(new GetAddressByIdRequest(id));
            
        [HttpPost("Insert")]
        public async Task<IResponse> InsertAsync(InsertAddressRequest request) => await _mediator.Send(request);

        [HttpPost("Update")]
        public async Task<IResponse> UpdateAsync(UpdateAddressRequest request) => await _mediator.Send(request);

        [HttpDelete("Delete")]
        public async Task<IResponse> DeleteAsync(Guid guid) => await _mediator.Send(new DeleteAddressRequest(guid));
    }
}
