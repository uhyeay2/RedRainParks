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
}
