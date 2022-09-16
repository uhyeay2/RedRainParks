using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class StateLookupRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository _repo { get; set ;}

        public StateLookupRepositoryTests()
        {
            _repo = new StateLookupRepository(_mockedConfig.Object);
        }

        [Test]
        public async Task GetStateEitherByIdOrAbbreviation_GivenId_Should_ReturnStateDetails()
        {
            var dc = await _repo.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(new(10));

            Assert.That(dc, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(dc.StateLookup_Id, Is.EqualTo(10));
                Assert.That(dc.StateLookup_Abbreviation, Is.EqualTo("DC"));
                Assert.That(dc.StateLookup_EnglishDisplay, Is.EqualTo("District of Columbia"));
                Assert.That(dc.StateLookup_SpanishDisplay, Is.EqualTo("Distrito Federal de Columbia"));
            });
        }

        [Test]
        public async Task GetStateEitherByIdOrAbbreviation_GivenAbbreviation_Should_ReturnStateDetails()
        {
            var dc = await _repo.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(new("dc"));

            Assert.That(dc, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(dc.StateLookup_Id, Is.EqualTo(10));
                Assert.That(dc.StateLookup_Abbreviation, Is.EqualTo("DC"));
                Assert.That(dc.StateLookup_EnglishDisplay, Is.EqualTo("District of Columbia"));
                Assert.That(dc.StateLookup_SpanishDisplay, Is.EqualTo("Distrito Federal de Columbia"));
            });
        }

        [Test]
        public async Task GetAllStates_Should_NotReturnEmpty() => 
            Assert.That(await _repo.FetchListAsync<GetAllStateLookupRequest, StateLookupDTO>(new ()), Is.Not.Empty);
    }
}
