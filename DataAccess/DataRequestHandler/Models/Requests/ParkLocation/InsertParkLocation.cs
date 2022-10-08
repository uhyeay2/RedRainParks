namespace DataRequestHandler.Models.Requests.ParkLocation
{
    [InsertQuery("ParkLocation")]
    public class InsertParkLocation : IRequestObject
    {
        public InsertParkLocation(Guid guid, string parkCode, string name, bool isActive)
        {
            Guid = guid;
            ParkCode = parkCode;
            Name = name;
            IsActive = isActive;
        }

        [Insertable("ParkLocation")]
        public Guid Guid { get; set; }

        [Insertable("ParkLocation")]
        public string ParkCode { get; set; }

        [Insertable("ParkLocation")]
        public string Name { get; set; }

        [Insertable("ParkLocation")]
        public bool IsActive { get; set; } = true;

        public object? GenerateParameters() => new { Guid, ParkCode, Name, IsActive };

        public string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Insert(typeof(InsertParkLocation));
    }
}
