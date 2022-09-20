using RedRainParks.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRainParks.Domain.Models.ParkLocationModels.Requests
{
    internal class InsertParkAddressRequest
    {
        public string ParkCode { get; set; }

        [Insertable]
        public string ReferenceName { get; set; }

        [Insertable]
        public bool IsActive { get; set; } = true;

        [Insertable]
        public int Rank { get; set; } = 1;

        #region Address 

        [Insertable]
        public string Line1 { get; set; }

        [Insertable]
        public string Line2 { get; set; }

        [Insertable]
        public string City { get; set; }

        [Insertable]
        public int StateId { get; set; }

        [Insertable]
        public string PostalCode { get; set; }

        #endregion
    }
}
