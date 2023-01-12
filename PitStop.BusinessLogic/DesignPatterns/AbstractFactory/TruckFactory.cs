using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.AbstractFactory
{
    public class TruckFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new Truck();
        }
    }
}
