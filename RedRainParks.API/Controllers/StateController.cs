using Microsoft.AspNetCore.Mvc;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels;
using RedRainParks.Domain.Models.StateModels.Requests;
using RedRainParks.Domain.Models.StateModels.Responses;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateLookupController
    {
        private readonly IStateLookupRepository _repo;

        public StateLookupController(IStateLookupRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("GetByIdOrAbbreviation")]
        public async Task<GetStateLookupResponse> GetByIdOrAbbreviationAsync(string request)
        {
            GetStateEitherByIdOrAbbreviation req = int.TryParse(request, out var id) ? new (id) : new (request);

            return req is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage) ?
                new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new (await _repo.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(req));            
        }

        [HttpGet("All")]
        public async Task<GetAllStateLookupResponse> GetAllAsync() => new (await _repo.FetchListAsync<GetAllStateLookupRequest, StateLookupDTO>(new()));

        [HttpGet("IsValidId")]
        public async Task<IsValidStateLookupIdResponse> IsValidStateLookupIdResponse(int id) => new ((await GetByIdOrAbbreviationAsync($"{id}"))?.State != null);
    }
}
