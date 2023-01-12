using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.AbstractFactory
{
    public class CarFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new Car();
        }
    }
}
