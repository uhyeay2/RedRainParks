namespace RedRainParks.Domain.Attributes
{
    public class FetchableAttribute : SqlPropertyIdentiferAttribute
    {
        public FetchableAttribute()
        {
        }

        public FetchableAttribute(string specifiedColumnName) : base(specifiedColumnName)
        {
        }
    }

    public class FetchQuery : SqlScriptAttribute
    {

        public string[]? Joins = null;

        public string? Where { get; set; }

        public string? OrderBy { get; set; }

        public string? Top { get; set; }

        public FetchQuery(string table) : base(table)
        {
        }

        public FetchQuery(string table, string where) : base(table)
        {
            Where = where;
        }

        public FetchQuery(string table, string[] joins, string where) : this(table, where)
        {
            Joins = joins;
        }

        public FetchQuery(string table, string join, string where) : this(table, where)
        {
            Joins = new[] { join };
        }

    }
}
