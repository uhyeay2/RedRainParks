using DataRequestHandler.Models.Requests.Address;
using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Mappings.Profiles
{
    internal class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            #region DTO -> Domain

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

            #endregion

            #region Request -> DataRequest

            CreateMap<GetAddressByGuid, GetAddressByGuidRequest>().ReverseMap();
            CreateMap<GetAddressById, GetAddressById>().ReverseMap();
            CreateMap<InsertAddress, InsertAddressRequest>().ReverseMap();
            CreateMap<DeleteAddress, DeleteAddressRequest>().ReverseMap();
            CreateMap<UpdateAddress, UpdateAddressRequest>().ReverseMap();

            #endregion
        }
    }
}
