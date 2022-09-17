namespace RedRainParks.Domain.Models.AddressModels
{
    public class AddressDTO
    {
        public AddressDTO()
        {

        }

        public AddressDTO(long address_Id, Guid address_Guid, DateTime address_CreatedAtDateInUTC, DateTime? address_LastUpdatedDateInUTC, string? address_Line1, string? address_Line2, string? address_City, int? address_StateId, string? address_PostalCode, int stateLookup_Id, string? stateLookup_Abbreviation, string? stateLookup_EnglishDisplay, string? stateLookup_SpanishDisplay)
        {
            Address_Id = address_Id;
            Address_Guid = address_Guid;
            Address_CreatedAtDateInUTC = address_CreatedAtDateInUTC;
            Address_LastUpdatedDateInUTC = address_LastUpdatedDateInUTC;
            Address_Line1 = address_Line1;
            Address_Line2 = address_Line2;
            Address_City = address_City;
            Address_StateId = address_StateId;
            Address_PostalCode = address_PostalCode;
            StateLookup_Id = stateLookup_Id;
            StateLookup_Abbreviation = stateLookup_Abbreviation;
            StateLookup_EnglishDisplay = stateLookup_EnglishDisplay;
            StateLookup_SpanishDisplay = stateLookup_SpanishDisplay;
        }

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
