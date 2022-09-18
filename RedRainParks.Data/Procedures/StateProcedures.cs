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
        private static string _selectStateLookup = $"{SharedSql.Select(StateLookupProperties.StateLookup)} FROM StateLookup WITH(NOLOCK)";

        public static string GetAll => _selectStateLookup;

        public static string IsValidId => $"SELECT {SharedSql.Exists("StateLookup", "Id = @Id")}";

        public static string GetByEitherIdOrAbbreviation = $"{_selectStateLookup} {SharedSql.WhereEither("Id", "Abbreviation")}";
    }
}
