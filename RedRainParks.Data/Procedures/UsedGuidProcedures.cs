namespace RedRainParks.Data.Procedures
{
    internal class UsedGuidProcedures
    {
        public const string Insert = "INSERT INTO UsedGuid (UniqueIdentifier) VALUES (@Guid)";

        public static readonly string DoesGuidExist = SharedSql.SelectExists("UsedGuid", "UniqueIdentifier = @Guid");

        public static readonly string Delete = SharedSql.Delete("UsedGuid", "UniqueIdentifier = @Guid");
    }
}
