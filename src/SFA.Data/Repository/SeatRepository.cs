using Microsoft.EntityFrameworkCore;
using SFA.Business.Interfaces;
using SFA.Business.Models;
using SFA.Data.Context;
using System;
using System.Threading.Tasks;

namespace SFA.Data.Repository
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        public SeatRepository(SfaDbContext context) : base(context) { }

        public async Task<Seat> GetSeatAirplane(Guid seatId)
        {
            return await _db.Seats.AsNoTracking()
                .Include(a => a.Airplane)
                .FirstOrDefaultAsync(a => a.Id == seatId);
        }
    }
}
