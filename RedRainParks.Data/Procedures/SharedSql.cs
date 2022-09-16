using RedRainParks.Domain.Extensions;

namespace RedRainParks.Data.Procedures
{
    internal static class SharedSql
    {
        public static string Coalesce(params string[] fields) => fields.Select(f => $"{f} = COALESCE(@{f}, {f})").AggregateWithCommas();

        public static string Delete(string table, string where) => $"DELETE FROM {table} WHERE {where}";

        /// <summary>
        /// Return a string representing WHERE condition - Example:
        /// $"WHERE ({column1} = {param1} OR {param1} IS NULL) AND ({column2} = {param2} OR {param2} IS NULL)"
        /// </summary>
        /// <param name="column1"></param>
        /// <param name="param1"></param>
        /// <param name="column2"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public static string WhereEither(string column1, string param1, string column2, string param2) =>
            $"WHERE ({column1} = {param1} OR {param1} IS NULL) AND ({column2} = {param2} OR {param2} IS NULL)";

        /// <summary>
        /// Return a string representing WHERE condition, If given ("Id", "Guid") then the response would be: 
        /// $"WHERE (Id = @Id OR @Id IS NULL) AND (Guid = @Guid OR @Guid IS NULL)"
        /// </summary>
        /// <param name="columnParamOne"></param>
        /// <param name="columnParamTwo"></param>
        /// <returns></returns>
        public static string WhereEither(string columnParamOne, string columnParamTwo) => WhereEither(columnParamOne, $"@{columnParamOne}", columnParamTwo, $"@{columnParamTwo}");
    }
}
