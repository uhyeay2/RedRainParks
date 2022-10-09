using RedRainParks.DataAccessMediator.Mappings.Profiles;

namespace RedRainParks.DataAccessMediator.Mappings
{
    public class MappingProfiles
    {
        public static MapperConfiguration GetMapperConfiguration() =>
        new(config =>
        {
            config.AllowNullDestinationValues = true;

            config.AddProfiles(new List<Profile>() { 
                new AddressMappingProfile(),
                new StateLookupMappingProfile()
            });
        });
    }
}
