namespace DataRequestHandler.Models.DTOs
{
    [FetchQuery("StateLookup WITH(NOLOCK)")]
    public class StateLookupDTO
    {
        [Fetchable]
        public int Id { get; set; }

        [Fetchable]
        public string Abbreviation { get; set; } = string.Empty;

        [Fetchable]
        public string? EnglishDisplay { get; set; }

        [Fetchable]
        public string? SpanishDisplay { get; set; }
    }
}
