namespace DataRequestHandler.Models.Requests.Address
{
    [InsertQuery("Address")]
    public class InsertAddress : GuidBasedRequest
    {
        public InsertAddress(Guid guid, string line1, string line2, string city, int stateId, string postalCode) : base(guid)
        {
            Guid = guid;
            Line1 = line1;
            Line2 = line2;
            City = city;
            StateId = stateId;
            PostalCode = postalCode;
        }

        [Insertable("Address")]
        public override Guid Guid { get; set; }

        [Insertable("Address")]
        public string Line1 { get; set; }

        [Insertable("Address")]
        public string Line2 { get; set; }

        [Insertable("Address")]
        public string City { get; set; }

        [Insertable("Address")]
        public int StateId { get; set; }

        [Insertable("Address")]
        public string PostalCode { get; set; }

        public override object? GenerateParameters() => new { Guid, Line1, Line2, City, StateId, PostalCode };

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Insert(typeof(InsertAddress));
    }
}
