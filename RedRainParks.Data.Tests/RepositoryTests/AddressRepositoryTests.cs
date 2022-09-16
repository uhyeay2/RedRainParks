using NUnit.Framework.Internal;
using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class AddressRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository _repo { get ; set ; }

        private readonly Guid _testGuid = Guid.NewGuid();

        private readonly InsertAddressRequest _defaultInsertRequest;

        public AddressRepositoryTests()
        {
            _repo = new AddressRepository(_mockedConfig.Object);

            _defaultInsertRequest = new(_testGuid, "AddressLine1", "AddressLine2", "City", 1, "32073");
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            var testAddress = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            if(testAddress != null)
            {
                await _repo.ExecuteAsync(new DeleteAddressByIdRequest(testAddress.Address_Id));
            }
        }

        [Test]
        public async Task InsertAddress_Given_ValidAddress_Should_InsertAddress()
        {
            // Insert Address
            await _repo.ExecuteAsync(_defaultInsertRequest);
            
            Assert.That(await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid)), Is.Not.Null);
        }

        [Test]
        public async Task UpdateAddressById_Given_NewValues_Should_UpdateRecord()
        {
            // Insert Address
            await _repo.ExecuteAsync(_defaultInsertRequest);

            // Fetch Inserted Record
            var insertedRecord = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(insertedRecord, Is.Not.Null);

            var updateRequest = new UpdateAddressByIdRequest()
            {
                Id = insertedRecord.Address_Id,
                Line1 = "UpdatedAddressLine1",
                Line2 = "UpdatedAddressLine2",
                City = "UpdatedCity",
                State = 25,
                PostalCode = "12321"
            };

            // Update Record
            await _repo.ExecuteAsync(updateRequest);

            var updatedRecord = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(updatedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(updatedRecord.Address_Line1, Is.EqualTo(updateRequest.Line1));
                Assert.That(updatedRecord.Address_Line2, Is.EqualTo(updateRequest.Line2));
                Assert.That(updatedRecord.Address_City, Is.EqualTo(updateRequest.City));
                Assert.That(updatedRecord.Address_StateId, Is.EqualTo(updateRequest.State));
                Assert.That(updatedRecord.Address_PostalCode, Is.EqualTo(updateRequest.PostalCode));
            });
        }

        [Test]
        public async Task DeleteAddressById_Given_AddressId_Should_DeleteRecord()
        {
            // Insert Address
            await _repo.ExecuteAsync(_defaultInsertRequest);

            // Fetch Inserted Record
            var insertedRecord = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(insertedRecord, Is.Not.Null);

            // Delete Record
            await _repo.ExecuteAsync(new DeleteAddressByIdRequest(insertedRecord.Address_Id));

            Assert.That(await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid)), Is.Null);
        }

        [Test]
        public async Task GetAddress_Should_ReturnFields_FromStateTable()
        {
            // Insert Address
            await _repo.ExecuteAsync(_defaultInsertRequest);

            // Fetch Inserted Record by Guid
            var insertedRecord = await _repo.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(insertedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(insertedRecord.StateLookup_Id, Is.EqualTo(_defaultInsertRequest.StateId));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_Abbreviation));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_EnglishDisplay));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_SpanishDisplay));
            });

            // Fetch Inserted Record By Id
            insertedRecord = await _repo.FetchAsync<GetAddressByIdRequest, AddressDTO>(new(insertedRecord.Address_Id));

            Assert.That(insertedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(insertedRecord.StateLookup_Id, Is.EqualTo(_defaultInsertRequest.StateId));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_Abbreviation));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_EnglishDisplay));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateLookup_SpanishDisplay));
            });
        }
    }
}
