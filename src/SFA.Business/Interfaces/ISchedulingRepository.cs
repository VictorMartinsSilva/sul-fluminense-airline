using System;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface ISchedulingRepository : IRepository<Scheduling>
    {
        Task<Scheduling> GetSchedulingFlight(Guid flightId);
    }
}