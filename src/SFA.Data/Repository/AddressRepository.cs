using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFA.Business.Interfaces;
using SFA.Business.Models;
using SFA.Data.Context;

namespace SFA.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(SfaDbContext context) : base(context) {}

        public async Task<Address> GetAddressPassenger(Guid passengerId)
        {
            return await _db.Addresses.AsNoTracking()
                .Include(a => a.Passenger)
                .FirstOrDefaultAsync(a => a.Id == passengerId);
        }
    }
}