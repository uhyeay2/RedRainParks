using Microsoft.AspNetCore.Mvc;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.BaseModels;
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
        public async Task<BaseResponse> GetByIdOrAbbreviationAsync(string request)
        {
            var req = int.TryParse(request, out var id) ? new GetStateEitherByIdOrAbbreviation(id) : new GetStateEitherByIdOrAbbreviation(request);

            if(req is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);
            }

            return new GetStateLookupResponse(await _repo.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(req));            
        } 
    }
}
