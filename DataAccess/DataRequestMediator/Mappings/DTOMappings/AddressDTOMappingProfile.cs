namespace RedRainParks.DataAccessMediator.Mappings.DTOMappings
{
    internal class AddressDTOMappingProfile : Profile
    {
        public AddressDTOMappingProfile()
        {
            CreateMap<AddressDTO, StateLookup>()
                .ForMember(state => state.Abbreviation, _ => _.MapFrom(dto => dto.StateAbbreviation))
                .ForMember(state => state.EnglishDisplay, _ => _.MapFrom(dto => dto.StateEnglishDisplay))
                .ForMember(state => state.SpanishDisplay, _ => _.MapFrom(dto => dto.StateSpanishDisplay))
            .ReverseMap();

            CreateMap<AddressDTO, Address>()
                .ForMember(domain => domain.State, _ => _.MapFrom(dto => dto))
                .ForMember(domain => domain.StreetLine1, _ => _.MapFrom(dto => dto.Line1))
                .ForMember(domain => domain.StreetLine2, _ => _.MapFrom(dto => dto.Line2))
            .ReverseMap();
        }
    }
}
