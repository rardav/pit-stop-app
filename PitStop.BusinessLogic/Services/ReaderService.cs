using PitStop.BusinessLogic.Contracts;
using PitStop.BusinessLogic.DesignPatterns.AbstractFactory;
using PitStop.BusinessLogic.DesignPatterns.Builder;
using PitStop.DataAccess.Entities;

namespace PitStop.BusinessLogic.Services
{
    public class ReaderService : IReaderService
    {
        public Fix ReadFixData(Random random, Vehicle vehicle)
        {
            Console.WriteLine("Add repair data:");

            Console.Write("Fixed part: ");
            var fixedPart = Console.ReadLine();

            var price = fixedPart.Length * random.Next(10, 21);
            Console.Write("This repair costs " + price + "EUR");

            var employeeId = random.Next(1, 4);

            var builder = new FixBuilder();
            builder.AddEmployeeId(employeeId);
            builder.AddFixedPart(fixedPart);
            builder.AddPrice(price);
            builder.AddDateOfFixing(DateTime.Today);
            builder.AddVehicleId(vehicle.Id);
            var fix = builder.Build();

            return fix;
        }

        public Vehicle ReadVehicleData(Random random, Client client)
        {
            var currentAnswer = "0";
            var menuValues = new string[] { "1", "2", "3" };
            Vehicle vehicle = null;
            while (!menuValues.Contains(currentAnswer))
            {
                Console.WriteLine("Choose a number according to vehicle type:\n\n1. Car\n2. Bus\n3. Truck\n");

                Console.Write("Your answer: ");
                currentAnswer = Console.ReadLine();

                switch (currentAnswer)
                {
                    case "1":
                        vehicle = new CarFactory().CreateVehicle();
                        break;
                    case "2":
                        vehicle = new BusFactory().CreateVehicle();
                        break;
                    case "3":
                        vehicle = new TruckFactory().CreateVehicle();
                        break;
                    default:
                        break;
                }
            }

            vehicle.ClientId = client.Id;

            Console.Clear();
            Console.WriteLine("Add vehicle data:");

            Console.Write("Manufacturer: ");
            vehicle.Manufacturer = Console.ReadLine();

            Console.Write("Model: ");
            vehicle.Model = Console.ReadLine();

            Console.Write("Plate number: ");
            vehicle.PlateNumber = Console.ReadLine();

            vehicle.Year = random.Next(2000, 2023);

            return vehicle;
        }

        public Client ReadClientData()
        {
            Console.WriteLine("Add client data:");
            var client = new Client();

            Console.Write("First Name: ");
            client.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            client.LastName = Console.ReadLine();

            Console.Write("Phone number: ");
            client.PhoneNumber = Console.ReadLine();

            return client;
        }
    }
}
