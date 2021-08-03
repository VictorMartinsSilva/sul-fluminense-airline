using System;

namespace SFA.Business.Models
{
    public class Address : Entity
    {
        public Guid PassengerId { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string UF { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Complement { get; set; }

        /* EF Relation */
        public Passenger Passenger { get; set; }
    }
}
