namespace RedRainParks.Data.Procedures
{
    internal class UsedGuidProcedures
    {
        public const string Insert = "INSERT INTO UsedGuids (UniqueIdentifier) VALUES (@Guid)";

        public static readonly string DoesGuidExist = $"SELECT {SharedSql.Exists("UsedGuids", "UniqueIdentifier = @Guid")}";

        public static readonly string Delete = SharedSql.Delete("UsedGuids", "UniqueIdentifier = @Guid");
    }
}
