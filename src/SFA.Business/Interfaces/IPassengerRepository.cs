using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        Task<Passenger> GetPassengerAddress(Guid id);
        Task<IEnumerable<Passenger>> GetPassengerAddresses();
        
        Task<Passenger> GetPassengerScheduling(Guid id);
        Task<IEnumerable<Passenger>> GetPassengerSchedules();
    }
}