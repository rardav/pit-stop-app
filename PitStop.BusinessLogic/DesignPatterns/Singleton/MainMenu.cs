using PitStop.BusinessLogic.DesignPatterns.AbstractFactory;
using PitStop.BusinessLogic.DesignPatterns.Builder;
using PitStop.BusinessLogic.Logic;
using PitStop.DataAccess.Context;
using PitStop.DataAccess.Entities;
using System.Text;

namespace PitStop.BusinessLogic.DesignPatterns.Singleton
{
    public sealed class MainMenu
    {
        private static readonly Lazy<MainMenu> _instance = new Lazy<MainMenu>(() => new MainMenu());

        private string _currentAnswer = "0";

        private PitStopContext _context;
        

        private MainMenu()
        {
            _context = new PitStopContext();

            _context.Database.EnsureCreated();
        }

        public static MainMenu Instance
        {
            get { return _instance.Value; }
        }

        private void Divider()
        {
            Console.WriteLine("\n=============================================================================================\n");
        }

        private void Clear()
        {
            Console.Clear();
        }

        private string Read()
        {
            var answer = Console.ReadLine();

            Clear();

            return answer;
        }

        private void ShowMainMenu()
        {
            var menuValues = new string[] {"1", "2","3"};
            while(!menuValues.Contains(_currentAnswer))
            {
                Console.WriteLine("Choose a number:\n\n1. Add new entry in the database\n2. Show last database entries.\n3. Exit\n");

                Console.Write("Your answer: ");
                _currentAnswer = Read();

                switch(_currentAnswer)
                {
                    case "1":
                        AddDbEntry();
                        _currentAnswer = "0";
                        break;
                    case "2":
                        ShowDbEntries();
                        _currentAnswer = "0";
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowDbEntries()
        {
            var query = new sDbService(_context);

            var fixes = query.GetLastTenFixesWithChildren();

            foreach (var fix in fixes)
            {
                var stringBuilder = GetFixString(fix);

                Console.WriteLine(stringBuilder);
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            Clear();
        }

        private static StringBuilder GetFixString(Fix fix)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(fix.DateOfFixing.ToString("dd/MM/yyyy"));
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Employee.FirstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Employee.LastName);
            stringBuilder.Append(" \t=>\t ");
            stringBuilder.Append(fix.Vehicle.Manufacturer);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Vehicle.Model);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Vehicle.PlateNumber);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.FixedPart);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Vehicle.Client.FirstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Vehicle.Client.LastName);

            return stringBuilder;
        }

        private void AddDbEntry()
        {
            var random = new Random();

            var client = ReadClientData();

            _context.Clients.Add(client);
            _context.SaveChanges();

            var vehicle = ReadVehicleData(random, client);

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            var fix = ReadFixData(random, vehicle);

            _context.Fixes.Add(fix);
            _context.SaveChanges();

        }

        private Fix ReadFixData(Random random, Vehicle vehicle)
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

        private Vehicle ReadVehicleData(Random random, Client client)
        {
            _currentAnswer = "0";
            var menuValues = new string[] { "1", "2", "3" };
            Vehicle vehicle = null;
            while (!menuValues.Contains(_currentAnswer))
            {
                Console.WriteLine("Choose a number according to vehicle type:\n\n1. Car\n2. Bus\n3. Truck\n");

                Console.Write("Your answer: ");
                _currentAnswer = Read();

                switch (_currentAnswer)
                {
                    case "1":
                        vehicle = new CarFactory().CreateVehicle();
                        ((Car)vehicle).AutomaticGearbox = random.Next(2) == 1;
                        break;
                    case "2":
                        vehicle = new BusFactory().CreateVehicle();
                        ((Bus)vehicle).NoOfSeats = random.Next(30, 55); ;
                        break;
                    case "3":
                        vehicle = new TruckFactory().CreateVehicle();
                        ((Truck)vehicle).Weight = random.Next(2, 5);
                        break;
                    default:
                        break;
                }
            }

            vehicle.ClientId = client.Id;

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

        private static Client ReadClientData()
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

        public void StartApp()
        {
            Console.WriteLine("Welcome to PitStop!");
            Divider();

            ShowMainMenu();
        }
    }
}
