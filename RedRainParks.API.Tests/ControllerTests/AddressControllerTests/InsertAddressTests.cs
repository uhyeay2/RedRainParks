using Moq;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.API.Tests.ControllerTests.AddressControllerTests
{
    public class InsertAddressTests : AddressControllerTest
    {
        [Test, Description("BadRequest - Guid"), TestCaseSource(nameof(InvalidGuids))]
        public async Task InsertAddress_Given_InvalidGuid_Should_ReturnStatusCode400(string guid) =>
            Assert.That((await _controller.InsertAsync(new(guid, "Line1", "Line2", "City", stateId: 1, "Postal"))).StatusCode, Is.EqualTo(400));

        [Test, Description("BadRequest - StateLookupId")]
        public async Task InsertAddress_Given_InvalidStateLookupId_Should_ReturnStatusCode400()
        {
            _mockedStateRepo.Setup(_ => _.FetchAsync<IsValidStateLookupIdRequest, bool>(It.IsNotNull<IsValidStateLookupIdRequest>())).Returns(Task.FromResult(false));

            Assert.That((await _controller.InsertAsync(new(Guid.NewGuid(), "Line1", "Line2", "City", stateId: 1, "Postal"))).StatusCode, Is.EqualTo(400));
        }

        [Test, Description("Valid Request")]
        public async Task InsertAddress_Given_ValidStateId_Should_ReturnStatusCode200()
        {
            _mockedStateRepo.Setup(_ => _.FetchAsync<IsValidStateLookupIdRequest, bool>(It.IsNotNull<IsValidStateLookupIdRequest>())).Returns(Task.FromResult(true));

            Assert.That((await _controller.InsertAsync(new(Guid.NewGuid(), "Line1", "Line2", "City", stateId: 1, "Postal"))).StatusCode, Is.EqualTo(200));
        }
    }
}
