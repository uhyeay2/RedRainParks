namespace RedRainParks.DataAccessMediator.Mappings.DTOMappings
{
    internal class StateLookupDTOMappingProfile : Profile
    {
        public StateLookupDTOMappingProfile()
        {
            CreateMap<StateLookup, StateLookupDTO>().ReverseMap();
        }
    }
}
