using Moq;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    public abstract class BaseRepositoryTest
    {
        protected readonly Mock<IConfig> _mockedConfig = new();

        private readonly TestDatabaseRepository _database;

        protected abstract IRepository Repository { get; set; }

        protected readonly Guid _testGuid = Guid.NewGuid();

        public BaseRepositoryTest()
        {
            _mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns(Hidden.TestEnvDatabaseConnectionString);
            _database = new(_mockedConfig.Object);
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _database.ClearTables();
        }
    }
}
