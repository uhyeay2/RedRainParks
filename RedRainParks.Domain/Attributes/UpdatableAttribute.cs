namespace RedRainParks.Domain.Attributes
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
