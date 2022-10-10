using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Tests.AddressHandlerTests
{
    [TestFixture]
    public class InsertAddressHandlerTest : HandlerTest
    {
        public InsertAddressHandlerTest() => Handler = new InsertAddressHandler(_mockDataHandler.Object, _mapper);

        private readonly InsertAddressHandler Handler;

        [Test]
        public async Task InsertAddress_Given_GuidIsInvalid_ShouldReturn_BadRequest400()
        {
            var request = new InsertAddressRequest(Guid.Empty, "Line1", "Line2", "City", StateId: 1, "Postal");

            var response = await Handler.Handle(request, default);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(400));
                Assert.That(response.Success, Is.EqualTo(false));
            });
        }
    }
}
