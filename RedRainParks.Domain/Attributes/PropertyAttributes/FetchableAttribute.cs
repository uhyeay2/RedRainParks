namespace RedRainParks.Domain.Attributes.PropertyAttributes
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
