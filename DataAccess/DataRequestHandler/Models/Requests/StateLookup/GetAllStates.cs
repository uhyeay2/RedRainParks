using DataRequestHandler.Models.BaseRequests;

namespace DataRequestHandler.Models.Requests.StateLookup
{
    public class GetAllStates : ParameterlessRequest
    {
        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(StateLookupDTO));
    }
}
