using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.UsedGuidModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    internal class UsedGuidsRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository _repo { get; set; }

        private readonly Guid _testGuid;

        public UsedGuidsRepositoryTests()
        {
            _repo = new UsedGuidsRepository(_mockedConfig.Object);
            _testGuid = Guid.NewGuid();
        }

        [Test]
        public async Task DoesGuidExist_Given_UuidDoesNotExist_Should_ReturnFalse() =>
            Assert.That(await _repo.FetchAsync<DoesGuidExistRequest, bool>(new(Guid.NewGuid())), Is.False);

        [Test]
        public async Task InsertGuid_GuidShouldExist_DeleteGuid_GuidShouldNotExist()
        {
            // Insert Guid
            await _repo.ExecuteAsync(new InsertGuidRequest(_testGuid));

            // Assert that Guid Exists
            Assert.That(await _repo.FetchAsync<DoesGuidExistRequest, bool>(new(_testGuid)), Is.True);

            // Delete Guid
            await _repo.ExecuteAsync(new DeleteGuidRequest(_testGuid));

            // Assert that Guid Does Not Exist
            Assert.That(await _repo.FetchAsync<DoesGuidExistRequest, bool>(new(_testGuid)), Is.False);
        }
    }
}
