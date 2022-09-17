using Microsoft.AspNetCore.Mvc;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;
using RedRainParks.Domain.Models.AddressModels.Responses;
using RedRainParks.Domain.Models.BaseModels;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IStateLookupRepository _stateLookupRepo;

        public AddressController(IAddressRepository addressRepo, IStateLookupRepository stateLookupRepo)
        {
            _addressRepo = addressRepo;
            _stateLookupRepo = stateLookupRepo;
        }

        [HttpPost("GetByGuid")]
        public async Task<GetAddressByGuidResponse> GetByGuidAsync([FromHeader] string guid, string stateDisplay = "English")
        {
            var request = new GetAddressByGuidRequest(guid);

            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
                return new(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);

            return new (await _addressRepo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(request), stateDisplay);
        }            
            
        [HttpPost("Insert")]
        public async Task<ExecutionResponse> InsertAsync(InsertAddressRequest request)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
                return new(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);

            if (!await _stateLookupRepo.FetchAsync<IsValidStateLookupIdRequest, bool>(new(request.StateId)))
                return new(Domain.Constants.StatusCodes.BadRequest_400, $"Invalid StateId Provided! No State Found With Id: {request.StateId}");

            return new( await _addressRepo.ExecuteAsync(request));
        }
        

        [HttpPost("Update")]
        public async Task<ExecutionResponse> UpdateAsync(UpdateAddressByIdRequest request) => request is IValidatable validatable && 
            !validatable.IsValid(out var failedValidationMessage) ? new (Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new(await _addressRepo.ExecuteAsync(request));

        [HttpDelete("Delete")]
        public async Task<ExecutionResponse> DeleteAsync(DeleteAddressByIdRequest request) => request is IValidatable validatable &&
            !validatable.IsValid(out var failedValidationMessage) ? new(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage)
                : new(await _addressRepo.ExecuteAsync(request));
    }
}
