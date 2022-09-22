using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.ParkLocationModels;
using RedRainParks.Domain.Models.ParkLocationModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    public class ParkLocationRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository Repository { get; set; }

        private readonly InsertParkLocationRequest _defaultInsertRequest;

        public ParkLocationRepositoryTests()
        {
            Repository = new ParkLocationRepository(_mockedConfig.Object);

            _defaultInsertRequest = new InsertParkLocationRequest(_testGuid, "Park Code", "Park Name", isActive: true);
        }

        [Test, Description("Insert ParkLocation Returns 1 When Valid")]
        public async Task InsertParkLocation_Given_LocationIsInserted_Should_ReturnOne() => Assert.That(await Repository.ExecuteAsync(_defaultInsertRequest), Is.EqualTo(1));

        [Test]
        public async Task InsertParkLocation_Given_LocationGuidIsNotUnique_Should_ThrowSqlException()
        {
            await Repository.ExecuteAsync(_defaultInsertRequest);

            Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(async () => await Repository.ExecuteAsync(_defaultInsertRequest));
        }

        [Test, Description("Get Park Location - Location Is Found")]
        public async Task GetParkLocation_Given_ValidRequest_Should_ReturnParkLocation()
        {
            await Repository.ExecuteAsync(_defaultInsertRequest);

            var insertedRecord = await Repository.FetchAsync<GetParkLocationByIdOrParkCodeRequest, ParkLocationDTO>(new (_defaultInsertRequest.ParkCode));

            Assert.That(insertedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(insertedRecord.Name, Is.EqualTo(_defaultInsertRequest.Name));
                Assert.That(insertedRecord.ParkCode, Is.EqualTo(_defaultInsertRequest.ParkCode));
                Assert.That(insertedRecord.IsActive, Is.EqualTo(_defaultInsertRequest.IsActive));
            });
        }

        [Test]
        public async Task InsertParkAddress_Given_ValidRequest_ShouldReturnTwo()
        {
            // insert Park Location
            await Repository.ExecuteAsync(_defaultInsertRequest);

            var insertAddressRequest = new InsertParkAddressRequest(_defaultInsertRequest.ParkCode!, "Main Entrance", isActive: true, rank: 1,
                addressGuid: Guid.NewGuid(), "Line1", "Line2", "City", stateId: 20, "Postal");

            var recordsInserted = await Repository.ExecuteAsync(insertAddressRequest);

            Assert.That(recordsInserted, Is.EqualTo(2));
        }

    }
}
