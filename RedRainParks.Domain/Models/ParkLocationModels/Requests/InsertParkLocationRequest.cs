using RedRainParks.Domain.Attributes;

namespace RedRainParks.Domain.Models.ParkLocationModels.Requests
{
    public class InsertParkLocationRequest
    {
        public InsertParkLocationRequest(Guid guid, string? parkCode, string? name, bool isActive)
        {
            Guid = guid;
            ParkCode = parkCode;
            Name = name;
            IsActive = isActive;
        }

        [Insertable]
        public Guid Guid { get; set; }

        [Insertable]
        public string? ParkCode { get; set; }

        [Insertable]
        public string? Name { get; set; }

        [Insertable]
        public bool IsActive { get; set; } = true;
    }
}
