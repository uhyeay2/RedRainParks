namespace DataRequestHandler.Models.Requests.Address
{
    public class GetAddressByGuid : GuidBasedRequest
    {
        public GetAddressByGuid(Guid guid) : base(guid) { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(AddressDTO), whereOverride: "Guid = @Guid");
    }
}
