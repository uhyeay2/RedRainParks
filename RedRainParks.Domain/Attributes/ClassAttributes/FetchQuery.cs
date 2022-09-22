﻿namespace RedRainParks.Domain.Attributes.ClassAttributes
{
    public class FetchQuery : SqlScriptAttribute
    {

        public string Joins = string.Empty;

        private string? _orderBy;
        public string OrderBy => string.IsNullOrWhiteSpace(_orderBy) ? string.Empty : "ORDER BY " + _orderBy;

        public string? Top { get; set; }

        public FetchQuery(string table) : base(table)
        {
        }

        public FetchQuery(string table, string where) : base(table, where)
        {
        }

        public FetchQuery(string table, string join, string where = "") : this(table, where)
        {
            Joins = join;
        }

        public FetchQuery(string table, string join = "", string where = "", string orderBy = "") : this(table, join, where)
        {
            _orderBy = orderBy;
        }
    }
}
