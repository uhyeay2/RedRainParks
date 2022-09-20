using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Models.AddressModels
{
    [FetchQuery(
        table: "Address WITH(NOLOCK)", 
        join: "LEFT JOIN StateLookup WITH(NOLOCK) ON Address.StateId = StateLookup.Id", 
        where: "Address.Id = @Id"
    )]
    public class AddressDTO
    {
        #region Constructors 
        public AddressDTO()
        {

        }

        public AddressDTO(long address_Id, Guid address_Guid, DateTime address_CreatedAtDateInUTC, DateTime? address_LastUpdatedDateInUTC, string? address_Line1, string? address_Line2, string? address_City, int? address_StateId, string? address_PostalCode, int stateLookup_Id, string? stateLookup_Abbreviation, string? stateLookup_EnglishDisplay, string? stateLookup_SpanishDisplay)
        {
            Id = address_Id;
            Guid = address_Guid;
            CreatedAtDateInUTC = address_CreatedAtDateInUTC;
            LastUpdatedDateInUTC = address_LastUpdatedDateInUTC;
            Line1 = address_Line1;
            Line2 = address_Line2;
            City = address_City;
            StateId = address_StateId;
            PostalCode = address_PostalCode;
            StateAbbreviation = stateLookup_Abbreviation;
            StateEnglishDisplay = stateLookup_EnglishDisplay;
            StateSpanishDisplay = stateLookup_SpanishDisplay;
        }

        #endregion

        #region Fields From Address Table

        [Fetchable("Address.Id")]
        public long Id { get; set; }

        [Fetchable]
        public Guid Guid { get; set; }

        [Fetchable]
        public DateTime CreatedAtDateInUTC { get; set; }

        [Fetchable]
        public DateTime? LastUpdatedDateInUTC { get; set; }

        [Fetchable]
        public string? Line1 { get; set; }

        [Fetchable]
        public string? Line2 { get; set; }

        [Fetchable]
        public string? City { get; set; }

        [Fetchable]
        public int? StateId { get; set; }

        [Fetchable]
        public string? PostalCode { get; set; }

        #endregion

        #region Fields From StateLookup Table

        [Fetchable("StateLookup.Abbreviation")]
        public string? StateAbbreviation { get; set; }

        [Fetchable("StateLookup.EnglishDisplay")]
        public string? StateEnglishDisplay { get; set; }

        [Fetchable("StateLookup.SpanishDisplay")]
        public string? StateSpanishDisplay { get; set; }

        #endregion

    }
}
