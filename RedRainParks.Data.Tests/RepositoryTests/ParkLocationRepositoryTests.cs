using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
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

            _defaultInsertRequest = new InsertParkLocationRequest(_testGuid, "ParkCode", "ParkName", isActive: true);
        }

        [Test]
        public async Task InsertParkLocation_Given_LocationIsInserted_Should_ReturnOne() =>
            Assert.That(await Repository.ExecuteAsync(_defaultInsertRequest), Is.EqualTo(1));
    }
}
