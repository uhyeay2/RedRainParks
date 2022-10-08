namespace DataRequestHandler.Models.Requests.Address
{
    public class DeleteAddressById : LongIdBasedRequest
    {
        public DeleteAddressById(long id) : base(id) { }

        public override string GenerateSql() => SqlGenerator.Delete("Address", "Id = @Id");
    }
}
