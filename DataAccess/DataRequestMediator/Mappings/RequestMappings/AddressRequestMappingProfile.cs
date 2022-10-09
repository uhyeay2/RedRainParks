using DataRequestHandler.Models.Requests.Address;
using DataRequestMediator.Handlers.AddressHandlers;

namespace RedRainParks.DataAccessMediator.Mappings.RequestMappings
{
    internal class AddressRequestMappingProfile : Profile
    {
        public AddressRequestMappingProfile()
        {
            CreateMap<GetAddressByGuid, GetAddressByGuidRequest>().ReverseMap();
            CreateMap<GetAddressById, GetAddressById>().ReverseMap();
            CreateMap<InsertAddress, InsertAddressRequest>().ReverseMap();
            CreateMap<DeleteAddressById, DeleteAddressByIdRequest>().ReverseMap();
            CreateMap<UpdateAddressById, UpdateAddressRequest>().ReverseMap();
        }
    }
}
