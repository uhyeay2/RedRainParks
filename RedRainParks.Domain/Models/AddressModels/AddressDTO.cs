namespace RedRainParks.Domain.Models.AddressModels
{
    public class AddressDTO
    {
        public long Address_Id { get; set; }

        public Guid Address_Guid { get; set; }

        public DateTime Address_CreatedAtDateInUTC { get; set; }

        public DateTime? Address_LastUpdatedDateInUTC { get; set; }

        public string? Address_Line1 { get; set; }

        public string? Address_Line2 { get; set; }

        public string? Address_City { get; set; }

        public int? Address_StateId { get; set; }

        public string? Address_PostalCode { get; set; }

        public int StateLookup_Id { get; set; }

        public string? StateLookup_Abbreviation { get; set; }

        public string? StateLookup_EnglishDisplay { get; set; }

        public string? StateLookup_SpanishDisplay { get; set; }
    }
}
