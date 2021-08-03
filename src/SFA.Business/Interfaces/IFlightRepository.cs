using System;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Task<Flight> GetFlightAirplane(Guid airplaneId);
    }
}