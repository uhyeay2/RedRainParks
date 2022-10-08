namespace DataRequestHandler.Models.Requests.ParkLocation
{
    public class GetParkAddressByIdOrParkCode : EitherByIntOrString
    {
        public GetParkAddressByIdOrParkCode(int? left) : base(left) { }

        public GetParkAddressByIdOrParkCode(string? right) : base(right) { }

        public override object? GenerateParameters() => new { Id = Left, ParkCode = Right };

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(ParkAddressDTO));
    }
}
