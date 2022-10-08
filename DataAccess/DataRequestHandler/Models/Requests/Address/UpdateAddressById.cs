namespace DataRequestHandler.Models.Requests.Address
{
    [UpdateQuery("Address", "Id = @Id")]
    public class UpdateAddressById : LongIdBasedRequest
    {
        public UpdateAddressById(long id, string? line1, string? line2, string? city, int? state, string? postalCode) : base(id)
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

        [Updatable(true, "StateId")]
        public int? State { get; set; }

        [Updatable(isCoalesceUpdate: true)]
        public string? PostalCode { get; set; }

        public override object? GenerateParameters() => new { Id, Line1, Line2, City, State, PostalCode };

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Update(typeof(UpdateAddressById));
    }
}
