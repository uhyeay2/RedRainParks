using RedRainParks.Domain.Extensions;
using RedRainParks.Domain.Models.StateModels;

namespace RedRainParks.Data.Procedures
{
    internal static class StateLookupProperties
    {
        public static readonly (string DatabaseName, string PropertyName)[] StateLookup = typeof(StateLookupDTO).GetSqlPropertyNames();
    }

    internal static class StateLookupProcedures
    {
        private static string _selectFromStateLookup = SharedSql.Select(StateLookupProperties.StateLookup) + " FROM StateLookup WITH(NOLOCK)";

        public static string GetAll => _selectFromStateLookup;

        public static string IsValidId => SharedSql.SelectExists("StateLookup", "Id = @Id");

        public static string GetByEitherIdOrAbbreviation = $"{_selectFromStateLookup} {SharedSql.WhereEither("Id", "Abbreviation")}";
    }
}
