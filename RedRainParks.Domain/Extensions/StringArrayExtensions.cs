namespace RedRainParks.Domain.Extensions
{
    public static class StringArrayExtensions
    {
        public static string AggregateWithCommas(this IEnumerable<string> strings) => 
            strings?.Any() ?? false ? strings.Aggregate((a, b) => $"{a}, {b}") : string.Empty;
    }
}
