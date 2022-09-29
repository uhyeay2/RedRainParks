using Moq;
using RedRainParks.API.Controllers;
using RedRainParks.Domain.Interfaces;
using RedRainParks.Domain.Models.AddressModels;

namespace RedRainParks.API.Tests.ControllerTests.AddressControllerTests
{
    public abstract class AddressControllerTest
    {
        protected AddressController _controller;

        protected Mock<IAddressRepository> _mockedAddressRepo;
        
        protected Mock<IStateLookupRepository> _mockedStateRepo;

        protected readonly AddressDTO? _testDto;

        //Shared Test Case
        public static readonly object[] InvalidGuids = { Guid.Empty.ToString(), null!, "BadGuid", "", "         ", "123", "12-23-1987" };

        public AddressControllerTest()
        {
            _testDto = new(address_Id: 54321, address_Guid: Guid.NewGuid(), address_CreatedAtDateInUTC: DateTime.UtcNow, address_LastUpdatedDateInUTC: DateTime.Now, 
                "Line 1", "Line 2", "City", address_StateId: 21, "32073-1234", "Abbreviation", "English", "Spanish");
        }

        [SetUp]
        public void SetUp()
        {
            _mockedAddressRepo = new Mock<IAddressRepository>();
            _mockedStateRepo = new Mock<IStateLookupRepository>();
            _controller = new(_mockedAddressRepo.Object, _mockedStateRepo.Object);
        }
    }
}
