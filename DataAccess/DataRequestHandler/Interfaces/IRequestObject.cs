namespace DataRequestHandler.Interfaces
{
    public interface IRequestObject
    {
        public object? GenerateParameters();

        public string GenerateSql();
    }
}
