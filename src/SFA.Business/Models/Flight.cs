using System;
using System.Collections.Generic;

namespace SFA.Business.Models
{
    public class Flight : Entity
    {
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool Active { get; set; }


        public Guid AirPlaneId { get; set; }
        public Airplane AirPlanes { get; set; }
        public IEnumerable<Scheduling> Schedules { get; set; }
    }
}
