namespace RedRainParks.Domain.Attributes
{
    internal class InsertableAttribute : SqlPropertyIdentiferAttribute
    {
        public InsertableAttribute()
        {
        }

        public InsertableAttribute(string specifiedColumnName) : base(specifiedColumnName)
        {
        }
    }
}
