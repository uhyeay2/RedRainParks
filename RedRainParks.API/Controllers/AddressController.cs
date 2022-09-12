using Microsoft.AspNetCore.Mvc;
using RedRainParks.API.Configuration;
using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels.DataTransferObjects;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController
    {
        //TODO: DependencyInjection
        private readonly IAddressRepository _repo = new AddressRepository(new ApiConfig());

        public AddressController()
        {

        }

        [HttpGet("GetById")]
        public async Task<AddressDTO?> GetById(int id) => await _repo.FetchAsync<GetAddressByIdRequest, AddressDTO>(new GetAddressByIdRequest(id));
    }
}
