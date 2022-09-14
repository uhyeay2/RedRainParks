using NUnit.Framework.Internal;
using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class AddressRepositoryTests
    {
        private readonly IAddressRepository _repo = new AddressRepository(new TestConfig());

        [Test]
        public async Task InsertAddress_Given_ValidAddress_Should_InsertAddress()
        {
            var guid = Guid.NewGuid();

            await _repo.ExecuteAsync(new InsertAddressRequest(guid, "Address Line 1", "Address Line 2", "City", stateId: 1, "PostalCode"));
            
            var result = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new GetAddressByGuidRequest(guid.ToString()));

            Assert.That(result, Is.Not.Null);
        }
    }
}
