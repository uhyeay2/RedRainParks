using DataRequestMediator.Handlers.StateLookupHandlers;
using Microsoft.AspNetCore.Mvc;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator) => _mediator = mediator;

        [HttpGet("all")]
        public async Task<IResponse> GetAll() => await _mediator.Send(new GetAllStatesRequest());

        [HttpGet("getByIdOrAbbreviation")]
        public async Task<IResponse> GetByAbbreviaiton(string identifier) => await _mediator.Send(new GetStateByIdOrAbbreviationRequest(identifier));

    }
}
