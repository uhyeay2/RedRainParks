namespace RedRainParks.Domain.Attributes.ClassAttributes
{
    public class FetchQuery : SqlScriptAttribute
    {

        public string Joins = string.Empty;

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

        public FetchQuery(string table, string join, string where = "") : this(table, where)
        {
            Joins = join;
        }

        public FetchQuery(string table, string join = "", string where = "", string orderBy = "") : this(table, join, where)
        {
            OrderBy = orderBy;
        }


    }
}
