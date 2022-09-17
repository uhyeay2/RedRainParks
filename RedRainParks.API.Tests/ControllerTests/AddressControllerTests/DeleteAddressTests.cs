using Moq;
using RedRainParks.Domain.Models.AddressModels.Requests;

namespace RedRainParks.API.Tests.ControllerTests.AddressControllerTests
{
    internal class DeleteAddressTests : AddressControllerTest
    {
        [Test, Description("BadRequest - Id")]
        public async Task DeleteAddress_Given_InvalidId_Should_ReturnStatusCode400() =>
            Assert.That((await _controller.DeleteAsync(new(0))).StatusCode, Is.EqualTo(400));

        [Test, Description("BadRequest - No Record Found")]
        public async Task DeleteAddress_Given_NoRecordDeleted_Should_ReturnStatusCode404()
        {
            _mockedAddressRepo.Setup(_ => _.ExecuteAsync(It.IsNotNull<DeleteAddressByIdRequest>())).Returns(Task.FromResult(0));

            Assert.That((await _controller.DeleteAsync(new(1))).StatusCode, Is.EqualTo(404));
        }

        [Test, Description("Valid Request")]
        public async Task DeleteAddress_Given_RecordIsDeleted_Should_ReturnStatusCode200()
        {
            _mockedAddressRepo.Setup(_ => _.ExecuteAsync(It.IsNotNull<DeleteAddressByIdRequest>())).Returns(Task.FromResult(1));

            Assert.That((await _controller.DeleteAsync(new(1))).StatusCode, Is.EqualTo(200));
        }
    }
}
