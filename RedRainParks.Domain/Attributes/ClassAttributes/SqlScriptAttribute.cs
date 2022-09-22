namespace RedRainParks.Domain.Attributes.ClassAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class SqlScriptAttribute : Attribute
    {
        public string Table { get; set; }

        public SqlScriptAttribute(string table)
        {
            Table = table;
        }
    }
}
