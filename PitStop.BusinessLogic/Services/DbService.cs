using Microsoft.EntityFrameworkCore;
using PitStop.DataAccess.Context;
using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Logic
{
    public class DbService
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
                .Reverse()
                .Take(10)
                .Reverse()
                .ToList();

            return fixes;
        }
    }
}
