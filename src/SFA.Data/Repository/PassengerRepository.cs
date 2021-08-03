using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFA.Business.Interfaces;
using SFA.Business.Models;
using SFA.Data.Context;

namespace SFA.Data.Repository
{
    public class PassengerRepository: Repository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(SfaDbContext context) : base(context){ }

        public async Task<IEnumerable<Passenger>> GetPassengerAddresses()
        {
            return await _db.Passengers
                .AsNoTracking()
                .Include(p => p.Addresses)
                .ToListAsync();
        }
        public async Task<Passenger> GetPassengerAddress(Guid id)
        {
            return await _db.Passengers
                .AsNoTracking()
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Passenger>> GetPassengerSchedules()
        {
            return await _db.Passengers
                .AsNoTracking()
                .Include(p => p.SchedulingPassengers)
                .ToListAsync();
        }
        public async Task<Passenger> GetPassengerScheduling(Guid id)
        {
            return await _db.Passengers
                .AsNoTracking()
                .Include(p => p.SchedulingPassengers)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        
    }
}