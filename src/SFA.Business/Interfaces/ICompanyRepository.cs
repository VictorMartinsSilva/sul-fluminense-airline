using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompanyAirplanes();
        Task<Company> GetCompanyAirplane(Guid airplanesId);
    }
}