using DataRequestHandler.Models.DTOs;
using DataRequestHandler.Models.Requests.Address;

namespace RedRainParks.DataAccess.Tests.Address
{
    [TestFixture]
    public class GetAddressTests : DataAccessTest
    {
        [Test]
        public async Task GetAddressByGuid_Given_NoAddressFound_ShouldReturn_Null() =>
            Assert.That(await _dataHandler.FetchAsync<GetAddressByGuid, AddressDTO>(new(Guid.NewGuid())), Is.Null);

        [Test]
        public async Task GetAddressById_Given_NoAddressFound_ShouldReturn_Null() =>
            Assert.That(await _dataHandler.FetchAsync<GetAddressById, AddressDTO>(new(1)), Is.Null);

        [Test]
        public async Task GetAddress_Given_AddressExists_Should_ReturnAddress()
        {
            var guid = Guid.NewGuid();
            var line1 = "Line1";
            var line2 = "Line2";
            var city = "City";
            var stateId = 1;
            var postalCode = "Postal";

            await InsertRecord("Address", "Guid, Line1, Line2, City, StateId, PostalCode", $"'{guid}', '{line1}', '{line2}', '{city}', {stateId}, '{postalCode}'");

            var getByGuidResult = await _dataHandler.FetchAsync<GetAddressByGuid, AddressDTO>(new(guid));

            Assert.That(getByGuidResult, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(getByGuidResult.Guid, Is.EqualTo(guid));
                Assert.That(getByGuidResult.Line1, Is.EqualTo(line1));
                Assert.That(getByGuidResult.Line2, Is.EqualTo(line2));
                Assert.That(getByGuidResult.City, Is.EqualTo(city));
                Assert.That(getByGuidResult.StateId, Is.EqualTo(stateId));
                Assert.That(getByGuidResult.PostalCode, Is.EqualTo(postalCode));
            });

            var getByIdResult = await _dataHandler.FetchAsync<GetAddressById, AddressDTO>(new(getByGuidResult.Id));

            Assert.That(getByIdResult, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(getByIdResult.Id, Is.EqualTo(getByGuidResult.Id));
                Assert.That(getByIdResult.Guid, Is.EqualTo(guid));
                Assert.That(getByIdResult.Line1, Is.EqualTo(line1));
                Assert.That(getByIdResult.Line2, Is.EqualTo(line2));
                Assert.That(getByIdResult.City, Is.EqualTo(city));
                Assert.That(getByIdResult.StateId, Is.EqualTo(stateId));
                Assert.That(getByIdResult.PostalCode, Is.EqualTo(postalCode));
            });
        }
    }
}
