using PitStop.DataAccess.Entities;
using System.Text;

namespace PitStop.BusinessLogic.Contracts
{
    public interface IMainMenuService
    {
        public StringBuilder GetFixString(Fix fix);
    }
}
