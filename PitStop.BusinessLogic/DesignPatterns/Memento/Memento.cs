namespace PitStop.BusinessLogic.DesignPatterns.Memento
{
    public class Memento
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Year { get; set; }

        public Memento(string manufacturer, string model, string plateNumber, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            PlateNumber = plateNumber;
            Year = year;
        }
    }
}
