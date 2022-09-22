namespace RedRainParks.Domain.Attributes.ClassAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InsertQuery : SqlScriptAttribute
    {
        public InsertQuery(string table) : base(table)
        {
        }

        public InsertQuery(string table, string from, string where) : this(table)
        {
            From = from;
            Where = where;
        }

        public bool IsInsertSelectRequest => !string.IsNullOrWhiteSpace(From);

        public string From { get; set; } = string.Empty;

        public string Join { get; set; } = string.Empty;

        public string Where { get; set; } = string.Empty;

        

    }
}
