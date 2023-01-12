using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Contracts
{
    public interface IReaderService
    {
        public Fix ReadFixData(Random random, Vehicle vehicle);

        public Vehicle ReadVehicleData(Random random, Client client);

        public Client ReadClientData();

    }
}
