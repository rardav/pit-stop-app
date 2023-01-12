namespace PitStop.BusinessLogic.DesignPatterns.Builder
{
    public interface IBuilder
    {
        public void AddVehicleId(int vehicleId);

        public void AddEmployeeId(int employeeId);

        public void AddFixedPart(string fixedPart);

        public void AddDateOfFixing(DateTime dateOfFixing);

        public void AddPrice(decimal price);
    }
}
 