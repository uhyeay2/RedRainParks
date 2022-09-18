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
        #region Properties

        protected override IRepository Repository { get ; set ; }

        private readonly InsertAddressRequest _defaultInsertRequest;

        #endregion

        #region Constructor

        public AddressRepositoryTests()
        {
            Repository = new AddressRepository(_mockedConfig.Object);

            _defaultInsertRequest = new(_testGuid, "AddressLine1", "AddressLine2", "City", 1, "32073");
        }

        #endregion

        #region Insert Address Tests

        [Test]
        public async Task InsertAddress_Given_AddressIsInserted_Should_ReturnOne() =>
            Assert.That(await Repository.ExecuteAsync(_defaultInsertRequest), Is.EqualTo(1));

        [Test]
        public async Task InsertAddress_Given_ValidAddress_Should_InsertAddress()
        {
            // Insert Address
            await Repository.ExecuteAsync(_defaultInsertRequest);
            
            Assert.That(await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid)), Is.Not.Null);
        }

        #endregion

        #region Update Address Tests

        [Test]
        public async Task UpdateAddress_Given_NoAddressExisted_Should_ReturnZero() =>
            Assert.That(await Repository.ExecuteAsync(new UpdateAddressByIdRequest(1, "Line1", "Line2", "City", state: 10, "Postal")), Is.EqualTo(0));

        [Test]
        public async Task UpdateAddress_Given_AddressIsUpdated_Should_ReturnOne()
        {
            var insertedRecord = await InsertAndFetchRecord();

            Assert.That(await Repository.ExecuteAsync(new UpdateAddressByIdRequest(insertedRecord.Id, "Line1", "Line2", "City", state: 10, "Postal")), Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateAddressById_Given_EmptyStrings_ClearsFields_ExceptState()
        {
            var insertedRecord = await InsertAndFetchRecord();

            // Update Record
            await Repository.ExecuteAsync(new UpdateAddressByIdRequest(insertedRecord.Id, "", "", "", state: null, ""));

            var updatedRecord = await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(updatedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(updatedRecord.Line1, Is.Empty);
                Assert.That(updatedRecord.Line2, Is.Empty);
                Assert.That(updatedRecord.City, Is.Empty);
                Assert.That(updatedRecord.PostalCode, Is.Empty);
            });
        }

        [Test]
        public async Task UpdateAddressById_Given_NewValues_Should_UpdateRecord()
        {
            var insertedRecord = await InsertAndFetchRecord();

            var updateRequest = new UpdateAddressByIdRequest(insertedRecord.Id, "UpdatedAddressLine1", "UpdatedAddressLine2", "UpdatedCity", state: 25, "12321");

            // Update Record
            await Repository.ExecuteAsync(updateRequest);

            var updatedRecord = await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(updatedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(updatedRecord.Line1, Is.EqualTo(updateRequest.Line1));
                Assert.That(updatedRecord.Line2, Is.EqualTo(updateRequest.Line2));
                Assert.That(updatedRecord.City, Is.EqualTo(updateRequest.City));
                Assert.That(updatedRecord.StateId, Is.EqualTo(updateRequest.State));
                Assert.That(updatedRecord.PostalCode, Is.EqualTo(updateRequest.PostalCode));
            });
        }

        [Test]
        public async Task UpdateAddressById_Given_NullValues_Should_LeaveRecordAsIs()
        {
            var insertedRecord = await InsertAndFetchRecord();

            // Update Record
            await Repository.ExecuteAsync(new UpdateAddressByIdRequest(insertedRecord.Id, null, null, null, null, null));

            var updatedRecord = await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(updatedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(updatedRecord.Line1, Is.EqualTo(insertedRecord.Line1));
                Assert.That(updatedRecord.Line2, Is.EqualTo(insertedRecord.Line2));
                Assert.That(updatedRecord.City, Is.EqualTo(insertedRecord.City));
                Assert.That(updatedRecord.StateId, Is.EqualTo(insertedRecord.StateId));
                Assert.That(updatedRecord.PostalCode, Is.EqualTo(insertedRecord.PostalCode));
            });
        }

        #endregion

        #region Delete Address Tests

        [Test]
        public async Task DeleteAddress_Given_NoAddressExisted_Should_ReturnZero() =>
            Assert.That(await Repository.ExecuteAsync(new DeleteAddressByIdRequest(1)), Is.EqualTo(0));

        [Test]
        public async Task DeleteAddress_Given_AddressIsDeleted_Should_ReturnOne()
        {
            var insertedRecord = await InsertAndFetchRecord();

            Assert.That(await Repository.ExecuteAsync(new DeleteAddressByIdRequest(insertedRecord.Id)), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAddressById_Given_AddressId_Should_DeleteRecord()
        {
            var insertedRecord = await InsertAndFetchRecord();

            // Delete Record
            await Repository.ExecuteAsync(new DeleteAddressByIdRequest(insertedRecord.Id));

            Assert.That(await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid)), Is.Null);
        }

        #endregion

        #region Get Address Tests

        [Test]
        public async Task GetAddress_Should_ReturnFields_FromStateTable()
        {
            var insertedRecord = await InsertAndFetchRecord();

            Assert.Multiple(() =>
            {
                Assert.That(insertedRecord.StateId, Is.EqualTo(_defaultInsertRequest.StateId));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateAbbreviation));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateEnglishDisplay));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateSpanishDisplay));
            });

            // Fetch Inserted Record By Id
            insertedRecord = await Repository.FetchAsync<GetAddressByIdRequest, AddressDTO>(new(insertedRecord.Id));

            Assert.That(insertedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(insertedRecord.StateId, Is.EqualTo(_defaultInsertRequest.StateId));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateAbbreviation));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateEnglishDisplay));
                Assert.That(!string.IsNullOrWhiteSpace(insertedRecord.StateSpanishDisplay));
            });
        }

        #endregion

        #region Helper Method

        private async Task<AddressDTO> InsertAndFetchRecord()
        {
            // Insert Address
            await Repository.ExecuteAsync(_defaultInsertRequest);

            // Fetch Inserted Record by Guid
            var insertedRecord = await Repository.FetchAsync<GetAddressByGuidRequest, AddressDTO>(new(_testGuid));

            Assert.That(insertedRecord, Is.Not.Null);

            return insertedRecord;
        }

        #endregion
    }
}
