using System;
using System.Collections.Generic;

namespace SFA.Business.Models
{
    public class Airplane : Entity
    {
        public string AirplaneModel { get; set; }
        public string SerialNumber { get; set; }
        public int PassengerNumber { get; set; }
        public int Capacity { get; set; }
        public bool Active { get; set; }


        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public IEnumerable<Seat> Seats { get; set; }

        public IEnumerable<Flight> Flights { get; set; }
    }
}
