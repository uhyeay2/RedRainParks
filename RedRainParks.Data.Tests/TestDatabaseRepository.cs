using Dapper;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.Data.Tests
{
    public class TestDatabaseRepository : RepositoryBase
    {
        protected override Dictionary<Type, object> _inputAndTargetSqlMappings { get; set; }

        public TestDatabaseRepository(IConfig config) : base(config)
        {
            _inputAndTargetSqlMappings = new()
            {
                { typeof(ClearTable.Address), new SqlAndSqlParamsFuncMap<ClearTable.Address>("DELETE FROM Address", requestObj =>  null! )},
                { typeof(ClearTable.ParkLocationAddress), new SqlAndSqlParamsFuncMap<ClearTable.ParkLocationAddress>("DELETE FROM ParkLocationAddress", requestObj =>  null! )},
                { typeof(ClearTable.ParkLocation), new SqlAndSqlParamsFuncMap<ClearTable.ParkLocation>("DELETE FROM ParkLocation", requestObj =>  null! )},
                { typeof(ClearTable.UsedGuid), new SqlAndSqlParamsFuncMap<ClearTable.UsedGuid>("DELETE FROM UsedGuid", requestObj =>  null! )},
            };
        }

        public static class ClearTable
        {
            public class Address { }
            public class ParkLocationAddress { }
            public class ParkLocation { }
            public class UsedGuid { }
        }

        public async Task ClearTables()
        {
            await ExecuteAsync(new ClearTable.ParkLocationAddress());
            await ExecuteAsync(new ClearTable.Address());
            await ExecuteAsync(new ClearTable.ParkLocation());
            await ExecuteAsync(new ClearTable.UsedGuid());
        }
    }
}
