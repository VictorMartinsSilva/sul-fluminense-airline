using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface IAirplaneRepository : IRepository<Airplane>
    {
        Task<Airplane> GetAirplaneCompany(Guid companyId);
        Task<IEnumerable<Airplane>> GetAirplaneSeats();
        Task<IEnumerable<Airplane>> GetAirplaneCompanies();
    }
}