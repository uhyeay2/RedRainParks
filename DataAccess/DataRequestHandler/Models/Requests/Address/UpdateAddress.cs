namespace DataRequestHandler.Models.Requests.Address
{
    [UpdateQuery("Address", "Guid = @Guid")]
    public class UpdateAddress : GuidBasedRequest
    {
        public UpdateAddress(Guid guid, string? line1, string? line2, string? city, int? state, string? postalCode) : base(guid)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        [Updatable(isCoalesceUpdate: true)]
        public string? Line1 { get; set; }

        [Updatable(isCoalesceUpdate: true)]
        public string? Line2 { get; set; }

        [Updatable(isCoalesceUpdate: true)]
        public string? City { get; set; }

        [Updatable(isCoalesceUpdate: true, "StateId")]
        public int? State { get; set; }

        [Updatable(isCoalesceUpdate: true)]
        public string? PostalCode { get; set; }

        public override object? GenerateParameters() => new { Guid, Line1, Line2, City, State, PostalCode };

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Update(typeof(UpdateAddress));
    }
}
