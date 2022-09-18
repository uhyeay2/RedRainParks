namespace RedRainParks.Domain.Models.StateModels
{
    public class StateLookup
    {
        public string Abbreviation { get; set; }

        public string EnglishDisplay { get; set; }

        public string SpanishDisplay { get; set; }

        public StateLookup(string abbreviation, string? englishDisplay, string? spanishDisplay)
        {
            Abbreviation = abbreviation;
            EnglishDisplay = englishDisplay ?? string.Empty;
            SpanishDisplay = spanishDisplay ?? string.Empty;
        }

        public StateLookup(StateLookupDTO dto) : this(dto.Abbreviation, dto.EnglishDisplay, dto.SpanishDisplay)
        {
        }
    }
}
