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
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(SfaDbContext context) : base(context) { }

        public async Task<Airplane> GetAirplaneCompany(Guid airplanesId)
        {
            return await _db.Airplanes.AsNoTracking()
                .Include(c => c.Company)
                .FirstOrDefaultAsync(c => c.Id == airplanesId);
        }

        public async Task<IEnumerable<Airplane>> GetAirplaneSeats()
        {
            return await _db.Airplanes.AsNoTracking()
                .Include(c => c.Seats)
                .ToListAsync();
        }

        public async Task<IEnumerable<Airplane>> GetAirplaneCompanies()
        {
            return await _db.Airplanes.AsNoTracking()
                .Include(c => c.Company)
                .ToListAsync();
        }
    }
}
