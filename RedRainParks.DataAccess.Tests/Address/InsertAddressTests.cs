using DataRequestHandler.Models.Requests.Address;

namespace RedRainParks.DataAccess.Tests.Address
{
    internal class InsertAddressTests : DataAccessTest
    {
        private readonly InsertAddress _testRequest = new (Guid.NewGuid(), "TestLine1", "TestLine2", "TestCity", 23, "TestPostal");

        [Test]
        public async Task InsertAddress_Given_AddressIsInserted_ShouldReturn_One() =>
           Assert.That(await _dataHandler.ExecuteAsync(_testRequest), Is.EqualTo(1));

        [Test]
        public async Task InsertAddress_Given_GuidIsNotUnique_ShouldReturn_NegativeOne()
        {
            await _dataHandler.ExecuteAsync(_testRequest);

            Assert.That(await _dataHandler.ExecuteAsync(_testRequest), Is.EqualTo(-1));
        }
    }
}
