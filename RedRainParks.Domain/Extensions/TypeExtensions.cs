using RedRainParks.Domain.Attributes.SQLGeneration;

namespace RedRainParks.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static (string SpecifiedOrDefaultName, string ActualPropertyName)[] GetSqlPropertyNames(this Type? type) => type?.GetProperties()
            .Where(c => c.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(typeof(SqlPropertyIdentiferAttribute))))?
                .Select(p => ((Attribute.GetCustomAttribute(p, typeof(SqlPropertyIdentiferAttribute)) as SqlPropertyIdentiferAttribute)!
                    .SpecifiedDatabaseName ?? p.Name, p.Name))
                        .ToArray() ?? Array.Empty<(string, string)>();

        public static IEnumerable<(string PropertyName, TPropertyIdentifier Attribute)> GetSqlProperties<TPropertyIdentifier>(this Type type) where TPropertyIdentifier : SqlPropertyIdentiferAttribute =>
            type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(TPropertyIdentifier)))?
                    .Select(p => (p.Name, (Attribute.GetCustomAttribute(p, typeof(TPropertyIdentifier)) as TPropertyIdentifier)!))
                        ?? Enumerable.Empty<(string, TPropertyIdentifier)>();
    }
}
