using System;

namespace SFA.Business.Models
{
    public class SchedulingPassenger : Entity
    {
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public Guid SchedulingId { get; set; }
        public Scheduling Scheduling { get; set; }

    }
}
