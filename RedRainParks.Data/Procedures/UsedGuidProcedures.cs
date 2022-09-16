namespace RedRainParks.Data.Procedures
{
    internal class UsedGuidProcedures
    {
        public const string DoesGuidExist = "SELECT CASE WHEN EXISTS(SELECT Id FROM UsedGuids WITH(NOLOCK) WHERE UniqueIdentifier = @Guid) THEN 1 ELSE 0 END";

        public const string Insert = "INSERT INTO UsedGuids (UniqueIdentifier) VALUES (@Guid)";

        public static readonly string Delete = SharedSql.Delete("UsedGuids", "UniqueIdentifier = @Guid");
    }
}
