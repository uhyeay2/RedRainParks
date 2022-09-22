namespace RedRainParks.Domain.Attributes.PropertyAttributes
{
    public class InsertableAttribute : SqlPropertyIdentiferAttribute
    {
        public InsertableAttribute(string tableName)
        {
            TableName = tableName;
        }

        public InsertableAttribute(string tableName, string specifiedColumnName, bool useScopedIdentity, string sqlTypeName) : this(tableName, specifiedColumnName)
        {
            UseScopedIdentity = useScopedIdentity;
            SqlTypeName = sqlTypeName;
        }

        public InsertableAttribute(string tableName, string specifiedColumnName) : this(tableName)
        {
            SpecifiedColumnName = specifiedColumnName;
        }

        public InsertableAttribute(string tableName, string specifiedColumnName, string fromTableColumnName) : this(tableName, specifiedColumnName)
        {
            FromColumnName = fromTableColumnName;
        }

        public bool UseScopedIdentity;

        public string? SqlTypeName { get; set; }

        public string TableName { get; set; }

        public string FromNameOrParameterName(string propertyName) => string.IsNullOrWhiteSpace(FromColumnName) ? $"@{propertyName}" : FromColumnName;

        public string FromColumnName { get; set; } = string.Empty;
    }
}
