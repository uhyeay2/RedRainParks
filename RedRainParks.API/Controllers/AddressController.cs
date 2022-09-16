using Microsoft.AspNetCore.Mvc;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;
using RedRainParks.Domain.Models.AddressModels.Responses;
using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {
        private readonly IAddressRepository _repo;

        public AddressController(IAddressRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("GetByGuid")]
        public async Task<GetAddressByGuidResponse> GetByGuidAsync([FromHeader] string guid, string stateDisplay = "English")
        {
            var request = new GetAddressByGuidRequest(guid);

            return request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage) ?
                new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage) 
                : new (await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(request), stateDisplay);
        }            
            
        [HttpPost("Insert")]
        public async Task<ExecutionResponse> InsertAsync(InsertAddressRequest request) => request is IValidatable validatable && 
            !validatable.IsValid(out var failedValidationMessage) ? new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new( await _repo.ExecuteAsync(request));

        [HttpPost("Update")]
        public async Task<ExecutionResponse> UpdateAsync(UpdateAddressByIdRequest request) => request is IValidatable validatable && 
            !validatable.IsValid(out var failedValidationMessage) ? new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new(await _repo.ExecuteAsync(request));

        [HttpDelete("Delete")]
        public async Task<ExecutionResponse> DeleteAsync(DeleteAddressByIdRequest request) => request is IValidatable validatable &&
            !validatable.IsValid(out var failedValidationMessage) ? new(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new(await _repo.ExecuteAsync(request));
    }
}
