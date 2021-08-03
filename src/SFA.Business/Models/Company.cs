using System.Collections.Generic;

namespace SFA.Business.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public bool Active { get; set; }


        public IEnumerable<Airplane> Airplanes { get; set; }
    }
}
