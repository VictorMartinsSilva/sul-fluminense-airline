using System;
using System.Collections.Generic;


namespace SFA.Business.Models
{
    public class Scheduling : Entity
    {
        public int HandBaggage { get; set; }
        public int CheckedBaggage { get; set; }
        public decimal Price { get; set; }



        public Guid FlightId { get; set; }
        public Flight Flights { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seats { get; set; }

        public IEnumerable<SchedulingPassenger> SchedulingPassengers { get; set; }
    }
}
