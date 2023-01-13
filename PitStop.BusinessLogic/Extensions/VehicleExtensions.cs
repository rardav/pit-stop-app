using PitStop.BusinessLogic.DesignPatterns.Memento;
using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Extensions
{
    public static class VehicleExtensions
    {
        public static Memento SaveMemento(this Vehicle vehicle)
        {
            return new Memento(vehicle.Manufacturer, vehicle.Model, vehicle.PlateNumber, vehicle.Year);
        }

        public static void RestoreMemento(this Vehicle vehicle, Memento memento)
        {
            vehicle.Manufacturer = memento.Manufacturer;
            vehicle.Model = memento.Model;
            vehicle.PlateNumber = memento.PlateNumber;
            vehicle.Year = memento.Year;
        }
    }
}
