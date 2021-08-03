using System.Collections.Generic;


namespace SFA.Business.Models
{
    public class Passenger : Entity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypePerson TypePerson { get; set; }
        public string Passport { get; set; }
        public string Document { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; }


        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<SchedulingPassenger> SchedulingPassengers { get; set; }
    }
}
