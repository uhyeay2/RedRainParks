using AutoMapper;
using DataRequestHandler.Interfaces;
using Moq;
using RedRainParks.DataAccessMediator.Mappings;

namespace RedRainParks.DataAccessMediator.Tests
{
    public abstract class HandlerTest
    {
        protected readonly Mock<IDataHandler> _mockDataHandler = new();

        protected readonly IMapper _mapper = MappingProfiles.GetMapperConfiguration().CreateMapper();
    }
}
