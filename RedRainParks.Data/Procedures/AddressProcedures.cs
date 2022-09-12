namespace RedRainParks.Data.Procedures
{
    internal static class AddressProcedures
    {
        public const string GetById = "SELECT Address.* FROM Address WITH(NOLOCK) WHERE Address.Id = @Id";

        public const string GetByGuid = "SELECT Address.* FROM Address WITH(NOLOCK) WHERE Address.Guid = @Guid";

        public const string Insert = "PROC_INSERT_Address";
    }
}
