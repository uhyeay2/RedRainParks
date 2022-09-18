using RedRainParks.Data.Repositories;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.StateModels;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.Data.Tests.RepositoryTests
{
    [TestFixture]
    public class StateLookupRepositoryTests : BaseRepositoryTest
    {
        protected override IRepository Repository { get; set ;}

        // This should match a record from Database StateLookupDTO table
        public readonly StateLookupDTO _testDTO = new()
        {
            Id = 10,
            Abbreviation = "DC",
            EnglishDisplay = "District of Columbia",
            SpanishDisplay = "Distrito Federal de Columbia"
        };

        public StateLookupRepositoryTests()
        {
            Repository = new StateLookupRepository(_mockedConfig.Object);
        }

        #region Is Valid StateLookup Id

        [Test]
        public async Task IsValidStateLookupId_Given_NoStateExists_Should_ReturnFalse() =>
            Assert.That(await Repository.FetchAsync<IsValidStateLookupIdRequest, bool>(new(0)), Is.False);


        [Test]
        public async Task IsValidStateLookupId_Given_StateDoesExists_Should_ReturnTrue() =>
            Assert.That(await Repository.FetchAsync<IsValidStateLookupIdRequest, bool>(new(_testDTO.Id)), Is.True);

        #endregion

        #region Get State Either By Id Or Abbreviation

        [Test]
        public async Task GetStateEitherByIdOrAbbreviation_GivenId_Should_ReturnStateDetails()
        {
            var fetchedRecord = await Repository.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(new(_testDTO.Id));

            Assert.That(fetchedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(fetchedRecord.Id, Is.EqualTo(_testDTO.Id));
                Assert.That(fetchedRecord.Abbreviation, Is.EqualTo(_testDTO.Abbreviation));
                Assert.That(fetchedRecord.EnglishDisplay, Is.EqualTo(_testDTO.EnglishDisplay));
                Assert.That(fetchedRecord.SpanishDisplay, Is.EqualTo(_testDTO.SpanishDisplay));
            });
        }

        [Test]
        public async Task GetStateEitherByIdOrAbbreviation_GivenAbbreviation_Should_ReturnStateDetails()
        {
            var fetchedRecord = await Repository.FetchAsync<GetStateEitherByIdOrAbbreviation, StateLookupDTO>(new(_testDTO.Abbreviation));

            Assert.That(fetchedRecord, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(fetchedRecord.Id, Is.EqualTo(_testDTO.Id));
                Assert.That(fetchedRecord.Abbreviation, Is.EqualTo(_testDTO.Abbreviation));
                Assert.That(fetchedRecord.EnglishDisplay, Is.EqualTo(_testDTO.EnglishDisplay));
                Assert.That(fetchedRecord.SpanishDisplay, Is.EqualTo(_testDTO.SpanishDisplay));
            });
        }

        #endregion

        [Test]
        public async Task GetAllStates_Should_NotReturnEmpty() =>
            Assert.That(await Repository.FetchListAsync<GetAllStateLookupRequest, StateLookupDTO>(new()), Is.Not.Empty);
    }
}
