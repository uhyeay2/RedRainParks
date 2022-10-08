namespace DataRequestHandler.Models.BaseRequests
{
    public abstract class EitherByIntOrString : Either<int?, string?>, IRequestObject
    {
        protected EitherByIntOrString(int? left) : base(left)
        {
        }

        protected EitherByIntOrString(string? right) : base(right)
        {
        }

        public virtual object? GenerateParameters() => new { Left, Right };

        public abstract string GenerateSql();
    }
}
