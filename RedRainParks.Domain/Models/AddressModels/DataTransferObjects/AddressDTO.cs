namespace RedRainParks.Domain.Models.AddressModels.DataTransferObjects
{
    public class AddressDTO
    {
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public DateTime CreatedAtDateInUTC { get; set; }

        public DateTime? LastUpdatedDateInUTC { get; set; }


        public string? Line1 { get; set; }

        public string? Line2 { get; set; }

        public string? City { get; set; }

        public int? State { get; set; }

        public string? PostalCode { get; set; }
    }
}
