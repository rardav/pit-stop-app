using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.DesignPatterns.Builder
{
    public class FixBuilder : IBuilder
    {
        private Fix _fix = new Fix();

        public FixBuilder()
        {
            _fix = new Fix();
        }

        public void AddDateOfFixing(DateTime dateOfFixing)
        {
            _fix.DateOfFixing = dateOfFixing;
        }

        public void AddEmployeeId(int employeeId)
        {
             _fix.EmployeeId = employeeId;
        }

        public void AddFixedPart(string fixedPart)
        {
            _fix.FixedPart = fixedPart;
        }

        public void AddPrice(decimal price)
        {
            _fix.Price = price;
        }

        public void AddVehicleId(int vehicleId)
        {
            _fix.VehicleId = vehicleId;
        }

        public Fix Build()
        {
            var result = _fix;

            _fix = new Fix();

            return result;
        }
    }
}
