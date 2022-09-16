using RedRainParks.Data.Attributes;

namespace RedRainParks.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPropertyNamesForSelect(this Type? type) => type?.GetProperties().Select(p => p.Name).AggregateDTOPropertiesForSelect() ?? string.Empty;

        public static IEnumerable<string> GetUpdatablePropertyNames(this Type? type) => type?.GetProperties()
            .Where(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(UpdatableAttribute)))
            .Select(p => ((UpdatableAttribute)Attribute.GetCustomAttribute(p, typeof(UpdatableAttribute))!).CustomColumnName ?? p.Name) ?? Enumerable.Empty<string>();
    }
}
