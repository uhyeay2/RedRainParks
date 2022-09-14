namespace RedRainParks.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPropertyNamesForSelect(this Type? type) => type?.GetProperties().Select(p => p.Name).AggregateDTOPropertiesForSelect() ?? string.Empty;
    }
}
