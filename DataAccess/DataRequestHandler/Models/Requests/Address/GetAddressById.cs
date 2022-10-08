namespace DataRequestHandler.Models.Requests.Address
{
    public class GetAddressById : LongIdBasedRequest
    {
        public GetAddressById(long id) : base(id) { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(AddressDTO));
    }
}
