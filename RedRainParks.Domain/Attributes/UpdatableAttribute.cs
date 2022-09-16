namespace RedRainParks.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UpdatableAttribute : Attribute
    {
        public string? CustomColumnName { get; set; } = null;

        public UpdatableAttribute(string customColumnName)
        {
            CustomColumnName = customColumnName;
        }

        public UpdatableAttribute()
        {
        }
    }
}
