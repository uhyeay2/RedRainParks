using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.UsedGuidModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    internal class UsedGuidsRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository Repository { get; set; }

        public UsedGuidsRepositoryTests()
        {
            Repository = new UsedGuidsRepository(_mockedConfig.Object);
        }

        #region Does Guid Exist

        [Test]
        public async Task DoesGuidExist_Given_GuidDoesNotExist_Should_ReturnFalse() =>
            Assert.That(await Repository.FetchAsync<DoesGuidExistRequest, bool>(new(Guid.NewGuid())), Is.False);

        [Test]
        public async Task DoesGuidExist_Given_GuidExists_Should_ReturnTrue()
        {
            // Insert Guid
            await Repository.ExecuteAsync(new InsertGuidRequest(_testGuid));

            Assert.That(await Repository.FetchAsync<DoesGuidExistRequest, bool>(new(_testGuid)), Is.True);
        }

        #endregion

        #region Insert Guid

        [Test]
        public async Task InsertGuid_Given_GuidIsInserted_Should_ReturnOne() =>
            Assert.That(await Repository.ExecuteAsync(new InsertGuidRequest(_testGuid)), Is.EqualTo(1));

        [Test]
        public async Task InsertGuid_Given_GuidIsNotUnique_Should_ThrowSqlException()
        {
            await Repository.ExecuteAsync(new InsertGuidRequest(_testGuid));

            Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(async () => await Repository.ExecuteAsync(new InsertGuidRequest(_testGuid)));
        }

        #endregion

        #region Delete Guid

        [Test]
        public async Task DeleteGuid_Given_GuidDoesNotExist_Should_ReturnZero() =>
            Assert.That(await Repository.ExecuteAsync(new DeleteGuidRequest(_testGuid)), Is.EqualTo(0));

        [Test]
        public async Task DeleteGuid_Given_GuidIsDeleted_Should_ReturnOne()
        {
            await Repository.ExecuteAsync(new InsertGuidRequest(_testGuid));

            Assert.That(await Repository.ExecuteAsync(new DeleteGuidRequest(_testGuid)), Is.EqualTo(1));
        }

        #endregion

    }
}
