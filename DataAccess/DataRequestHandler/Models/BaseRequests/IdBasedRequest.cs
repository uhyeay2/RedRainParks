namespace DataRequestHandler.Models.BaseRequests
{
    public abstract class IdBasedRequest : IRequestObject
    {
        public IdBasedRequest(int id) => Id = id;

        public int Id { get; set; }

        public virtual object? GenerateParameters() => new { Id };

        public abstract string GenerateSql();
    }

    public abstract class LongIdBasedRequest : IRequestObject
    {
        public LongIdBasedRequest(long id) => Id = id;

        public long Id { get; set; }

        public virtual object? GenerateParameters() => new { Id };

        public abstract string GenerateSql();
    }
}
