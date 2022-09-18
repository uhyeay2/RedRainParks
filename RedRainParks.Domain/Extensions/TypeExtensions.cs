using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static (string SpecifiedOrDefaultName, string ActualPropertyName)[] GetSqlPropertyNames(this Type? type) => type?.GetProperties()
            .Where(c => c.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(typeof(SqlPropertyIdentiferAttribute))))?
                .Select(p => ((Attribute.GetCustomAttribute(p, typeof(SqlPropertyIdentiferAttribute)) as SqlPropertyIdentiferAttribute)!
                    .SpecifiedColumnName ?? p.Name, p.Name))
                        .ToArray() ?? Array.Empty<(string, string)>();
    }
}
