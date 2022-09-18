using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.AddressModels.Requests;
using RedRainParks.Domain.Models.StateModels;
using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Constants
{
    public static class DTOProperties
    {
        public static readonly string Address = typeof(AddressDTO).GetFetchableColumnNamesForSelect();

        public static readonly string[] AddressUpdateableFields = typeof(UpdateAddressByIdRequest).GetColumnNamesWithAttribute<UpdatableAttribute>().ToArray();

        public static readonly string StateLookup = typeof(StateLookupDTO).GetPropertyNamesForSelect();
    }
}
