using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;
using RedRainParks.Domain.Models.StateModels;

namespace RedRainParks.Domain.Constants
{
    public static class DTOProperties
    {
        public static readonly string Address = typeof(AddressDTO).GetPropertyNamesForSelect();

        public static readonly string[] AddressUpdateableFields = typeof(UpdateAddressByIdRequest).GetUpdatablePropertyNames().ToArray();

        public static readonly string StateLookup = typeof(StateLookupDTO).GetPropertyNamesForSelect();
    }
}
