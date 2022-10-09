using DataRequestHandler;
using DataRequestHandler.Interfaces;
using DataRequestHandler.Models.BaseRequests;
using Moq;
using RedRainParks.Domain.Interfaces;

namespace RedRainParks.DataAccess.Tests
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        protected readonly IDataHandler _dataHandler;

        public DataAccessTest()
        {
            var mockedConfig = new Mock<IConfig>();

            mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RedRainParksTestEnv;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            _dataHandler = new DataHandler(mockedConfig.Object);
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await ClearTable("Address");
        }

        #region Helpers For Setup/Teardown

        protected async Task InsertAddress(Guid guid, string line1 = "Line1", string line2 = "Line2", string city = "City", int state = 1, string postal = "Postal") =>
            await InsertRecord("Address", "Guid, Line1, Line2, City, StateId, PostalCode", $"'{guid}', '{line1}', '{line2}', '{city}', {state}, '{postal}'");


        protected async Task InsertRecord(string table, string columns, string values) => await _dataHandler.ExecuteAsync(new InsertRecordRequest(table, columns, values));

        protected async Task<TOutput?> InlineFetch<TOutput>(string sql) => await _dataHandler.FetchAsync<InlineSqlRequest, TOutput>(new(sql));

        private async Task ClearTable(string table) => await _dataHandler.ExecuteAsync(new ClearTableRequest(table));

        #region Request Objects 

        private class ClearTableRequest : ParameterlessRequest
        {
            public ClearTableRequest(string table) => Table = table;

            public string Table { get; set; }

            public override string GenerateSql() => $"DELETE FROM {Table}";
        }

        private class InsertRecordRequest : ParameterlessRequest
        {
            public InsertRecordRequest(string table, string columns, string values)
            {
                Table = table;
                Columns = columns;
                Values = values;
            }

            public string Table { get; set; }
            public string Columns { get; set; }
            public string Values { get; set; }

            public override string GenerateSql() => $"INSERT INTO {Table} ( {Columns} ) VALUES ( {Values} )";
        }

        private class InlineSqlRequest : ParameterlessRequest
        {
            public InlineSqlRequest(string sql) => _sql = sql;
            
            private readonly string _sql;

            public override string GenerateSql() => _sql;
        }

        #endregion
        
        #endregion
    }


}
