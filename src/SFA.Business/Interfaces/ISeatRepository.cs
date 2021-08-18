using SFA.Business.Models;
using System;
using System.Threading.Tasks;

namespace SFA.Business.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<Seat> GetSeatAirplane(Guid airplaneId);
    }
}
