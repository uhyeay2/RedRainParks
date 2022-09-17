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

        [HttpGet("AllStates")]
        public async Task<GetAllStateLookupResponse> GetAllAsync() => new(await _repo.FetchListAsync<GetAllStateLookupRequest, StateLookupDTO>(new()));

        [HttpPost("GetByIdOrAbbreviation")]
        public async Task<GetStateLookupResponse> GetByIdOrAbbreviationAsync(string idOrAbbreviation)
        {
            GetStateEitherByIdOrAbbreviation request = int.TryParse(idOrAbbreviation, out var id) ? new (id) : new (idOrAbbreviation);

            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);
            }

            return new (await _repo.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(request));            
        }

        [HttpGet("IsValidId")]
        public async Task<IsValidStateLookupIdResponse> IsValidStateLookupId(int id) 
        {
            var request = new IsValidStateLookupIdRequest(id);

            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new IsValidStateLookupIdResponse(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);
            }

            return new(await _repo.FetchAsync<IsValidStateLookupIdRequest, bool>(request));
        }
    }
}
