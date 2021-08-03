using System;
using System.Threading.Tasks;
using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressPassenger(Guid passengerId);
    }
}