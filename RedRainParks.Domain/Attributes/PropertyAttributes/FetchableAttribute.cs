namespace RedRainParks.Domain.Attributes.PropertyAttributes
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
}
