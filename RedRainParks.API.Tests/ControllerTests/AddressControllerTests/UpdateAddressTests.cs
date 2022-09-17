using Moq;
using RedRainParks.Domain.Models.AddressModels.Requests;
using RedRainParks.Domain.Models.StateModels.Requests;

namespace RedRainParks.API.Tests.ControllerTests.AddressControllerTests
{
    public class UpdateAddressTests : AddressControllerTest
    {
        [Test, Description("BadRequest - Id")]
        public async Task UpdateAddress_Given_InvalidId_Should_ReturnStatusCode400() =>
            Assert.That((await _controller.UpdateAsync(new(0, "Line1", "Line2", "City", state:1, "Postal"))).StatusCode, Is.EqualTo(400));

        [Test, Description("BadRequest - StateLookupId")]
        public async Task InsertAddress_Given_InvalidStateLookupId_Should_ReturnStatusCode400()
        {
            _mockedStateRepo.Setup(_ => _.FetchAsync<IsValidStateLookupIdRequest, bool>(It.IsNotNull<IsValidStateLookupIdRequest>())).Returns(Task.FromResult(false));

            Assert.That((await _controller.UpdateAsync(new(1, "Line1", "Line2", "City", state: 1, "Postal"))).StatusCode, Is.EqualTo(400));
        }

        [Test, Description("BadRequest - Not Found")]
        public async Task UpdateAddress_Given_NoAddressUpdated_Should_ReturnStatusCode404()
        {
            _mockedStateRepo.Setup(_ => _.FetchAsync<IsValidStateLookupIdRequest, bool>(It.IsNotNull<IsValidStateLookupIdRequest>())).Returns(Task.FromResult(true));

            _mockedAddressRepo.Setup(_ => _.ExecuteAsync(It.IsNotNull<UpdateAddressByIdRequest>())).Returns(Task.FromResult(0));
            
            Assert.That((await _controller.UpdateAsync(new(1, "Line1", "Line2", "City", state: 1, "Postal"))).StatusCode, Is.EqualTo(404));
        }

        [Test, Description("Valid Request")]
        public async Task UpdateAddress_Given_AddressUpdated_Should_ReturnStatusCode200()
        {
            _mockedStateRepo.Setup(_ => _.FetchAsync<IsValidStateLookupIdRequest, bool>(It.IsNotNull<IsValidStateLookupIdRequest>())).Returns(Task.FromResult(true));

            _mockedAddressRepo.Setup(_ => _.ExecuteAsync(It.IsNotNull<UpdateAddressByIdRequest>())).Returns(Task.FromResult(1));

            Assert.That((await _controller.UpdateAsync(new(1, "Line1", "Line2", "City", state: 1, "Postal"))).StatusCode, Is.EqualTo(200));
        }
    }
}
