using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPropertyNamesForSelect(this Type? type) => type?.GetProperties().Select(p => p.Name).AggregateDTOPropertiesForSelect() ?? string.Empty;

        public static IEnumerable<string> GetColumnNamesWithAttribute<TAttribute>(this Type? type) where TAttribute : SqlPropertyIdentiferAttribute => type?.GetProperties()
            .Where(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(TAttribute)))?
                .Select(p => (Attribute.GetCustomAttribute(p, typeof(SqlPropertyIdentiferAttribute)) as SqlPropertyIdentiferAttribute)!
                    .SpecifiedColumnName ?? p.Name) ?? Enumerable.Empty<string>();

        public static string GetFetchableColumnNamesForSelect(this Type? type) => type?.GetProperties()
            .Where(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(FetchableAttribute)))?
                .Select(p => ((Attribute.GetCustomAttribute(p, typeof(FetchableAttribute)) as FetchableAttribute)!
                    .SpecifiedColumnName ?? p.Name) + $" AS {p.Name}")
                        .AggregateWithCommas() ?? string.Empty;
    }
}
