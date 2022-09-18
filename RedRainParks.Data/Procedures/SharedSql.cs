using RedRainParks.Domain.Extensions;

namespace RedRainParks.Data.Procedures
{
    internal static class SharedSql
    {
        public static string Coalesce(params (string databaseName, string parameterName)[] columns) => columns.Select(c => $"{c.databaseName} = COALESCE(@{c.parameterName}, {c.databaseName})").AggregateWithCommas();

        public static string CoalesceUpdate(string table, (string databaseName, string parameterName)[] columns, string where) => 
            $"UPDATE {table} SET {columns.Select(c => $"{c.databaseName} = COALESCE(@{c.parameterName}, {c.databaseName})").AggregateWithCommas()} WHERE {where}";

        public static string Delete(string table, string where) => $"DELETE FROM {table} WHERE {where}";

        public static string Select((string databaseName, string parameterName)[] columns) => $"SELECT {columns.Select(c => $"{c.databaseName} AS {c.parameterName}").AggregateWithCommas()} ";
        
        public static string Select((string databaseName, string parameterName)[] columns, string from, string where = "", string orderBy = "") => 
            "SELECT " + columns.Select(c => $"{c.databaseName} AS {c.parameterName}").AggregateWithCommas() + $" {from} {where} {orderBy}";

        public static string Insert(string table, (string databaseName, string parameterName)[] columns) => 
            $"INSERT INTO {table} ({columns.Select(c=> c.databaseName).AggregateWithCommas()}) VALUES ({columns.Select(c => $"@{c.parameterName}").AggregateWithCommas()})";

        public static string SelectExists(string table, string condition, string column = "*") => $"SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END";

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
