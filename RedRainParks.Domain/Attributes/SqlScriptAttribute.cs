namespace RedRainParks.Domain.Attributes
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
