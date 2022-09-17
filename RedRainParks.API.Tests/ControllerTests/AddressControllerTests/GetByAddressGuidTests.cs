using Moq;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.API.Tests.ControllerTests.AddressControllerTests
{
    public class GetByAddressGuidTests : AddressControllerTest
    {
        [Test, Description("BadRequest - Guid"), TestCaseSource(nameof(InvalidGuids))]
        public async Task GetAddressByGuid_Given_InvalidGuid_Should_ReturnStatusCode400(string guid) =>
            Assert.That((await _controller.GetByGuidAsync(guid)).StatusCode, Is.EqualTo(400));

        [Test, Description("No Record Found")]
        public async Task GetAddressByGuid_Given_NoAddressFound_Should_ReturnStatusCode404() =>
            Assert.That((await _controller.GetByGuidAsync(Guid.NewGuid().ToString())).StatusCode, Is.EqualTo(404));

        [Test, Description("Fetch From Address")]
        public async Task GetAddressByGuid_Given_AddressFound_Should_ReturnValues()
        {
            _mockedAddressRepo.Setup(_ => _.FetchAsync<GetAddressByGuidRequest, AddressDTO>(It.IsAny<GetAddressByGuidRequest>()))
                .Returns(() => Task.FromResult(_testDto));

            var result = await _controller.GetByGuidAsync(Guid.NewGuid().ToString());

            Assert.Multiple(() =>
            {
                Assert.That(result.Address!.StreetLine1, Is.EqualTo(_testDto!.Address_Line1));
                Assert.That(result.Address!.StreetLine2, Is.EqualTo(_testDto!.Address_Line2));
                Assert.That(result.Address!.City, Is.EqualTo(_testDto!.Address_City));
                Assert.That(result.Address!.PostalCode, Is.EqualTo(_testDto!.Address_PostalCode));
            });
        }

        [Test, Description("Fetch State English Translation")]
        public async Task GetAddressByGuid_Given_EnglishStateDisplay_Should_ReturnEnglishState()
        {            
            _mockedAddressRepo.Setup(_ => _.FetchAsync<GetAddressByGuidRequest, AddressDTO>(It.IsAny<GetAddressByGuidRequest>()))
                .Returns(() => Task.FromResult(_testDto));

            var result = await _controller.GetByGuidAsync(Guid.NewGuid().ToString(), "English");

            Assert.That(result.Address!.State, Is.EqualTo(_testDto!.StateLookup_EnglishDisplay));
        }

        [Test, Description("Fetch State Spanish Translation")]
        public async Task GetAddressByGuid_Given_SpanishStateDisplay_Should_ReturnSpanishState()
        {
            _mockedAddressRepo.Setup(_ => _.FetchAsync<GetAddressByGuidRequest, AddressDTO>(It.IsAny<GetAddressByGuidRequest>()))
                .Returns(() => Task.FromResult(_testDto));

            var result = await _controller.GetByGuidAsync(Guid.NewGuid().ToString(), "Spanish");

            Assert.That(result.Address!.State, Is.EqualTo(_testDto!.StateLookup_SpanishDisplay));
        }

        [Test, Description("Fetch State Abbreviated")]
        public async Task GetAddressByGuid_Given_AbbreviationStateDisplay_Should_ReturnAbbreviatedState()
        {
            _mockedAddressRepo.Setup(_ => _.FetchAsync<GetAddressByGuidRequest, AddressDTO>(It.IsAny<GetAddressByGuidRequest>()))
                .Returns(() => Task.FromResult(_testDto));

            var result = await _controller.GetByGuidAsync(Guid.NewGuid().ToString(), "Abr");

            Assert.That(result.Address!.State, Is.EqualTo(_testDto!.StateLookup_Abbreviation));
        }
    }
}
