using Moq;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    public abstract class BaseRepositoryTest
    {
        protected readonly Mock<IConfig> _mockedConfig = new();

        protected abstract IRepository _repo { get; set; }

        public BaseRepositoryTest()
        {
            _mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns(Constants.TestDbConnectionString);
        }
    }
}
