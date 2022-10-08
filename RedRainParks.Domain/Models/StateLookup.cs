namespace RedRainParks.Domain.Models
{
    public class StateLookup
    {
        public StateLookup() { }

        public StateLookup(string abbreviation, string englishDisplay, string spanishDisplay)
        {
            Abbreviation = abbreviation;
            EnglishDisplay = englishDisplay;
            SpanishDisplay = spanishDisplay;
        }

        public string Abbreviation { get; set; } = string.Empty;

        public string EnglishDisplay { get; set; } = string.Empty;

        public string SpanishDisplay { get; set; } = string.Empty;
    }
}
