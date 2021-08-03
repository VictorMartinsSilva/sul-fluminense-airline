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
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(SfaDbContext context) : base(context) { }
        public async Task<Scheduling> GetSchedulingFlight(Guid schedulesId)
        {
            return await _db.Schedules.AsNoTracking()
                .Include(s => s.Flights)
                .FirstOrDefaultAsync(s => s.Id == schedulesId);
        }
    }
}
