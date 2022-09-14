namespace RedRainParks.Domain.Enums
{
    public enum StateDisplay
    {
        Abbreviation,
        English,
        Spanish
    }

    public static class StateDisplayExtensions
    {
        public static string? GetDisplayByLanguage(this StateDisplay language, string? abbreviation, string? englishDisplay, string? spanishDisplay) => language switch
        {
            StateDisplay.Abbreviation => abbreviation,
            StateDisplay.English => englishDisplay,
            StateDisplay.Spanish => spanishDisplay,
            _ => string.Empty
        };

        public static StateDisplay GetDisplayOrDefault(this string str) => str switch
        {
            var s when string.IsNullOrWhiteSpace(s) => StateDisplay.Abbreviation,
            var s when s.StartsWith("en", StringComparison.OrdinalIgnoreCase) => StateDisplay.English,
            var s when s.StartsWith("sp", StringComparison.OrdinalIgnoreCase) => StateDisplay.Spanish,
            _ => StateDisplay.Abbreviation
        };
}
}
