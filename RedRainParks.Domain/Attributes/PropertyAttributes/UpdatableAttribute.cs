namespace RedRainParks.Domain.Attributes.PropertyAttributes
{
    public class UpdatableAttribute : SqlPropertyIdentiferAttribute
    {
        public UpdatableAttribute()
        {
        }

        public UpdatableAttribute(string specifiedColumnName) : base(specifiedColumnName)
        {
        }
    }
}
