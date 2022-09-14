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
        public async Task<BaseResponse> GetByGuidAsync(GetAddressByGuidRequest request) =>
            request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage) ? new BaseResponse(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage) 
                : new GetAddressByGuidResponse(await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new GetAddressByGuidRequest(request.Guid)), request.Language);


        [HttpPost("Insert")]
        public async Task<BaseResponse> InsertAsync(InsertAddressRequest request)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(Domain.Constants.StatusCodes.BadRequest_400, failedValidationMessage);
            }

            await _repo.ExecuteAsync(request);

            return new BaseResponse();
        }
    }
}
