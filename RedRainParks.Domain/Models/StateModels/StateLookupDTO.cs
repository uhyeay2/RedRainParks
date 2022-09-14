namespace RedRainParks.Domain.Models.StateModels
{
    public class StateLookupDTO
    {
        public int StateLookup_Id { get; set; }

        public string StateLookup_Abbreviation { get; set; } = string.Empty;

        public string? StateLookup_EnglishDisplay { get; set; }

        public string? StateLookup_SpanishDisplay { get; set; }
    }
}
