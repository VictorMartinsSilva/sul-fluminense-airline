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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(SfaDbContext context) : base(context) { }

        public async Task<Company> GetCompanyAirplane(Guid airplanesId)
        {
            return await _db.Companies.AsNoTracking()
                .Include(c => c.Airplanes)
                .FirstOrDefaultAsync(c => c.Id == airplanesId);
        }
        public async Task<IEnumerable<Company>> GetCompanyAirplanes()
        {
            return await _db.Companies.AsNoTracking()
                .Include(c => c.Airplanes)
                .ToListAsync();
        }
    }
}
