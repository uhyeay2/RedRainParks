namespace RedRainParks.Domain.Attributes.PropertyAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SqlPropertyIdentiferAttribute : Attribute
    {
        /// <summary>
        /// SpecifiedColumnName is be to used when getting DTOProperties for Sql Procedures. If SpecifiedColumnName is left null then the PropertyName will be used.
        /// </summary>
        public string? SpecifiedColumnName { get; set; } = null;

        public SqlPropertyIdentiferAttribute()
        {

        }

        protected SqlPropertyIdentiferAttribute(string specifiedColumnName)
        {
            SpecifiedColumnName = specifiedColumnName;
        }
    }
}
