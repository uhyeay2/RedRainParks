namespace DataRequestHandler.Models.Requests.Address
{
    public class DeleteAddress : GuidBasedRequest
    {
        public DeleteAddress(Guid guid) : base(guid) { }

        public override string GenerateSql() => SqlGenerator.Delete("Address", "Guid = @Guid");
    }
}
