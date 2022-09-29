namespace RedRainParks.Domain.Attributes.SQLGeneration.InsertAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InsertQuery : SqlScriptAttribute
    {
        public InsertQuery(string table) : base(table)
        {
        }

        public InsertQuery(string table, string from, string where) : base(table, where)
        {
            From = from;
        }

        public bool IsInsertSelectRequest => !string.IsNullOrWhiteSpace(From);

        public string From { get; set; } = string.Empty;

        public string Join { get; set; } = string.Empty;

        public string GetValuesToInsert(string values) => IsInsertSelectRequest ? $"SELECT {values} FROM {From} {Join} {Where} " : $"VALUES ( {values} )";
    }
}
