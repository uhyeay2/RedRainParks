using RedRainParks.Domain.Attributes;
using RedRainParks.Domain.Attributes.PropertyAttributes;

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

        [Insertable("ParkLocation")]
        public Guid Guid { get; set; }

        [Insertable("ParkLocation")]
        public string? ParkCode { get; set; }

        [Insertable("ParkLocation")]
        public string? Name { get; set; }

        [Insertable("ParkLocation")]
        public bool IsActive { get; set; } = true;
    }
}
