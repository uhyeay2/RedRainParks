namespace RedRainParks.Domain.Extensions
{
    public static class StringArrayExtensions
    {
        public static string AggregateDTOPropertiesForSelect(this IEnumerable<string> strings) =>
            strings?.Any() ?? false ? strings.Select(x => $"{x.Replace('_', '.')} as {x}").Aggregate((a, b) => $"{a}, {b}") : string.Empty;
    }
}
