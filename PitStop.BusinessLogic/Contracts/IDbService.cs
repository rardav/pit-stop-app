using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Contracts
{
    public interface IDbService
    {
        public List<Fix> GetLastTenFixesWithChildren();

    }
}
