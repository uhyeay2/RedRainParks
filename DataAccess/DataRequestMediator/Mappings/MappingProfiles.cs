using RedRainParks.DataAccessMediator.Mappings.DTOMappings;
using RedRainParks.DataAccessMediator.Mappings.RequestMappings;

namespace RedRainParks.DataAccessMediator.Mappings
{
    public class MappingProfiles
    {
        public static MapperConfiguration GetMapperConfiguration() =>
        new(config =>
        {
            config.AllowNullDestinationValues = true;

            config.AddProfiles(new List<Profile>() { 
                new AddressDTOMappingProfile(), new AddressRequestMappingProfile(),
                new StateLookupDTOMappingProfile()
            });
        });
    }
}
