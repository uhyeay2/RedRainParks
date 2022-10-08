namespace DataRequestHandler.Models.Requests.ParkLocation
{
    public class GetParkLocationByIdOrParkCode : EitherByIntOrString
    {
        public GetParkLocationByIdOrParkCode(int? left) : base(left) { }

        public GetParkLocationByIdOrParkCode(string? right) : base(right) { }

        public override object? GenerateParameters() => new { Id = Left, ParkCode = Right };

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(ParkLocationDTO));
    }
}
