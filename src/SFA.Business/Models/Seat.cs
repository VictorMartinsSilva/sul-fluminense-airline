using System;
using System.Collections.Generic;

namespace SFA.Business.Models
{
    public class Seat : Entity
    {
        public int Number { get; set; }
        public string TypeClass { get; set; }

        public Guid AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public IEnumerable<Scheduling> Schedules { get; set; }
    }
}
