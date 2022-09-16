using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    internal class UsedGuidsRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository _repo { get; set; }

        public UsedGuidsRepositoryTests()
        {
            _repo = new UsedGuidsRepository(_mockedConfig.Object);
        }
    }
}
