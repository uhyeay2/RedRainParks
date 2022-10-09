namespace RedRainParks.DataAccessMediator.Mappings.Profiles
{
    internal class StateLookupMappingProfile : Profile
    {
        public StateLookupMappingProfile() 
        {
            CreateMap<StateLookup, StateLookupDTO>().ReverseMap();
        }
    }
}
