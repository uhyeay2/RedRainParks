using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.AddressModels;
using RedRainParks.Domain.Models.StateModels;

namespace RedRainParks.Domain.Constants
{
    public static class DTOProperties
    {
        public static string Address = typeof(AddressDTO).GetPropertyNamesForSelect();
        public static string StateLookup = typeof(StateLookupDTO).GetPropertyNamesForSelect();
    }
}
