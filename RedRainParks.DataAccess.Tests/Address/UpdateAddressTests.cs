using DataRequestHandler.Models.DTOs;
using DataRequestHandler.Models.Requests.Address;

namespace RedRainParks.DataAccess.Tests.Address
{
    [TestFixture]
    public class UpdateAddressTests : DataAccessTest
    {
        private readonly UpdateAddress _testRequest = new(Guid.NewGuid(), "UpdateOne", "UpdatedTwo", "UpdateCity", state: 2, "Update");

        [Test]
        public async Task UpdateAddress_Given_NoAddressExisted_Should_ReturnZero() =>
          Assert.That(await _dataHandler.ExecuteAsync(_testRequest), Is.EqualTo(0));

        [Test]
        public async Task UpdateAddress_Given_AddressIsUpdated_Should_ReturnOne()
        {            
            await InsertAddress(_testRequest.Guid);

            Assert.That(await _dataHandler.ExecuteAsync(_testRequest), Is.EqualTo(1));

            var result = await InlineFetch<AddressDTO>("SELECT * FROM Address LEFT JOIN StateLookup ON Address.StateId = StateLookup.Id");

            Assert.That(result, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(result.Guid, Is.EqualTo(_testRequest.Guid));
                Assert.That(result.Line1, Is.EqualTo(_testRequest.Line1));
                Assert.That(result.Line2, Is.EqualTo(_testRequest.Line2));
                Assert.That(result.City, Is.EqualTo(_testRequest.City));
                Assert.That(result.StateId, Is.EqualTo(_testRequest.State));
                Assert.That(result.PostalCode, Is.EqualTo(_testRequest.PostalCode));

                Assert.That(result.StateAbbreviation, Is.Not.Empty);
                Assert.That(result.StateEnglishDisplay, Is.Not.Empty);
                Assert.That(result.StateSpanishDisplay, Is.Not.Empty);
            });
        }

        [Test]
        public async Task UpdateAddress_Given_EmptyStrings_Should_ClearsFields()
        {
            await InsertAddress(_testRequest.Guid);

            var updateToClearFields = new UpdateAddress(_testRequest.Guid, "", "", "", state: null, "");

            var rows = await _dataHandler.ExecuteAsync(updateToClearFields);

            var result = await InlineFetch<AddressDTO>("SELECT * FROM Address LEFT JOIN StateLookup ON Address.StateId = StateLookup.Id");

            Assert.That(result, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(result.Line1, Is.Empty);
                Assert.That(result.Line2, Is.Empty);
                Assert.That(result.City, Is.Empty);
                Assert.That(result.PostalCode, Is.Empty);
            });
        }
    }
}
