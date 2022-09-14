using RedRainParks.Domain.Constants;

namespace RedRainParks.Data.Procedures
{
    internal static class StateProcedures
    {
        public static string GetByEitherIdOrAbbreviation = @$"SELECT {DTOProperties.StateLookup} FROM StateLookup 
            WHERE (@Id IS NULL OR ID = @ID) AND ( @Abbreviation IS NULL OR Abbreviation = @Abbreviation )";
    }
}
