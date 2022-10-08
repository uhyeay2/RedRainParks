namespace DataRequestHandler.SqlGeneration.Attributes.FetchAttributes
{
    public class FetchableAttribute : SqlPropertyIdentiferAttribute
    {
        public FetchableAttribute()
        {
        }

        public FetchableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
        }
    }
}
