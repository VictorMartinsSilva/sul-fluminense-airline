using Microsoft.EntityFrameworkCore;
using SFA.Business.Interfaces;
using SFA.Business.Models;
using SFA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.Data.Repository
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(SfaDbContext context) : base(context) { }
        public async Task<Flight> GetFlightAirplane(Guid flightsId)
        {
            return await _db.Flights.AsNoTracking()
                .Include(f => f.AirPlanes)
                .FirstOrDefaultAsync(f => f.Id == flightsId);
        }
    }
}
