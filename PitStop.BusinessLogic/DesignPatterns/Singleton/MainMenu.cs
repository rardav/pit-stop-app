using PitStop.BusinessLogic.Contracts;
using PitStop.BusinessLogic.Services;
using PitStop.DataAccess.Context;

namespace PitStop.BusinessLogic.DesignPatterns.Singleton
{
    public sealed class MainMenu
    {
        private static readonly Lazy<MainMenu> _instance = new Lazy<MainMenu>(() => new MainMenu());

        private PitStopContext _context;

        private IReaderService _readerService;

        private IMainMenuService _mainMenuService;

        private IDbService _dbService;
        

        private MainMenu()
        {
            _context = new PitStopContext();

            _context.Database.EnsureCreated();

            _readerService = new ReaderService();

            _mainMenuService = new MainMenuService();

            _dbService = new DbService(_context);
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
            string _currentAnswer = "0";
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
            var fixes = _dbService.GetLastTenFixesWithChildren();

            foreach (var fix in fixes)
            {
                var stringBuilder = _mainMenuService.GetFixString(fix);

                Console.WriteLine(stringBuilder);
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            Clear();
        }

        

        public void AddDbEntry()
        {
            var random = new Random();

            var client = _readerService.ReadClientData();

            _context.Clients.Add(client);
            _context.SaveChanges();

            Clear();

            var vehicle = _readerService.ReadVehicleData(random, client);

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            Clear();

            var fix = _readerService.ReadFixData(random, vehicle);

            _context.Fixes.Add(fix);
            _context.SaveChanges();

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            Clear();
        }

        

        public void StartApp()
        {
            Console.WriteLine("Welcome to PitStop!");
            Divider();

            ShowMainMenu();
        }
    }
}
