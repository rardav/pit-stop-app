using Microsoft.EntityFrameworkCore;
using PitStop.BusinessLogic.Contracts;
using PitStop.DataAccess.Context;
using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Services
{
    public class DbService : IDbService
    {
        private readonly PitStopContext _context;

        public DbService(PitStopContext context)
        {
            _context = context;
        }

        public List<Fix> GetLastTenFixesWithChildren()
        {
            var fixes = _context.Fixes
                .Include(fix => fix.Employee)
                .Include(fix => fix.Vehicle)
                .ThenInclude(vehicle => vehicle.Client)
                .AsEnumerable()
                .Reverse()
                .Take(10)
                .Reverse()
                .ToList();

            return fixes;
        }
    }
}
