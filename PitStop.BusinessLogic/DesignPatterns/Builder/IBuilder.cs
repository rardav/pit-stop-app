namespace PitStop.BusinessLogic.DesignPatterns.Builder
{
    public interface IBuilder
    {
        void AddManufacturer(string manufacturer);
        void AddModel(string model);
        void AddYear(int year);
        void AddPlateNumber(string plateNumber);
        void AddClientId(int clientId);
    }
}
