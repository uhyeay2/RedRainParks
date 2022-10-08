namespace DataRequestHandler.Models.BaseRequests
{
    public abstract class GuidBasedRequest : IRequestObject
    {
        public virtual Guid Guid { get; set; }

        public GuidBasedRequest(Guid guid) => Guid = guid;

        public virtual object? GenerateParameters() => new { Guid };

        public abstract string GenerateSql();
    }
}
