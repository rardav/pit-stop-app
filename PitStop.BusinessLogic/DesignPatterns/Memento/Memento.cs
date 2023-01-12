namespace PitStop.BusinessLogic.DesignPatterns.Memento
{
    public class Memento
    {
        public string FixedPart { get; set; }
        public DateTime DateOfFixing { get; set; }
        public decimal Price { get; set; }

        public Memento(string fixedPart, DateTime dateOfFixing, decimal price)
        {
            FixedPart = fixedPart;
            DateOfFixing = dateOfFixing;
            Price = price;
        }
    }
}
