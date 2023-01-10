using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.Builder
{
    public class VehicleBuilder : IBuilder
    {
        private Vehicle _vehicle = new Vehicle();

        public VehicleBuilder()
        {
            _vehicle = new Vehicle();
        }

        public void AddClientId(int clientId)
        {
            _vehicle.ClientId = clientId;
        }

        public void AddManufacturer(string manufacturer)
        {
            _vehicle.Manufacturer = manufacturer;
        }

        public void AddModel(string model)
        {
            _vehicle.Model = model;
        }

        public void AddPlateNumber(string plateNumber)
        {
            _vehicle.PlateNumber = plateNumber;
        }

        public void AddYear(int year)
        {
            _vehicle.Year = year;
        }

        public Vehicle Build()
        {
            var result = _vehicle;

            _vehicle = new Vehicle();

            return result;
        }
    }
}
