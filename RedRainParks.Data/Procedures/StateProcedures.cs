﻿using RedRainParks.Domain.Constants;

namespace RedRainParks.Data.Procedures
{
    internal static class StateLookupProcedures
    {
        private static string _selectStateLookup = $"SELECT {DTOProperties.StateLookup} FROM StateLookup WITH(NOLOCK)";

        public static string GetAll => _selectStateLookup;

        public static string IsValidId => $"SELECT {SharedSql.Exists("StateLookup", "Id = @Id")}";

        public static string GetByEitherIdOrAbbreviation = $"{_selectStateLookup} {SharedSql.WhereEither("Id", "Abbreviation")}";
    }
}
