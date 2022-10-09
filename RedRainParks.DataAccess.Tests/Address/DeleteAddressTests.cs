using DataRequestHandler.Models.DTOs;
using DataRequestHandler.Models.Requests.Address;

namespace RedRainParks.DataAccess.Tests.Address
{
    [TestFixture]
    public class DeleteAddressTests : DataAccessTest
    {
        [Test]
        public async Task DeleteAddress_Given_NoAddressExisted_Should_ReturnZero() =>
          Assert.That(await _dataHandler.ExecuteAsync(new DeleteAddress(Guid.NewGuid())), Is.EqualTo(0));

        [Test]
        public async Task DeleteAddress_Given_AddressIsDeleted_Should_ReturnOne()
        {
            var guid = Guid.NewGuid();

            await InsertAddress(guid);

            Assert.That(await _dataHandler.ExecuteAsync(new DeleteAddress(guid)), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAddressById_Given_AddressId_Should_DeleteRecord()
        {
            var guid = Guid.NewGuid();

            await InsertAddress(guid);

            await _dataHandler.ExecuteAsync(new DeleteAddress(guid));

            Assert.That(await InlineFetch<AddressDTO>("SELECT * FROM Address"), Is.Null);
        }
    }
}
