using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.AbstractFactory
{
    public class BusFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new Bus();
        }
    }
}
 