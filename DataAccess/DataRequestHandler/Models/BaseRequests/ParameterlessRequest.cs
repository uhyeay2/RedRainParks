namespace DataRequestHandler.Models.BaseRequests
{
    public abstract class ParameterlessRequest : IRequestObject
    {
        public object? GenerateParameters() => null;

        public abstract string GenerateSql();
    }
}
