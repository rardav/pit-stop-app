using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.AbstractFactory
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle();
    }
}
