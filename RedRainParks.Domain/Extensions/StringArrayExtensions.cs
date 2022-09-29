namespace RedRainParks.Domain.Extensions
{
    public static class StringArrayExtensions
    {
        public static string AggregateWithCommaNewLine(this IEnumerable<string> strings) => 
            strings?.Any() ?? false ? strings.Aggregate((a, b) => $"{a},\n {b}") : string.Empty;
    }
}
