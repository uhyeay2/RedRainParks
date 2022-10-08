using DataRequestHandler.Models.BaseRequests;

namespace DataRequestHandler.Models.Requests.StateLookup
{
    public class GetStateByIdOrAbbreviation : EitherByIntOrString
    {
        public GetStateByIdOrAbbreviation(int? left) : base(left) { }

        public GetStateByIdOrAbbreviation(string? right) : base(right) { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(StateLookupDTO), whereOverride: "(Id = @Left AND @Right IS NULL) OR (Abbreviation = @Right AND @Left IS NULL)");
    }
}