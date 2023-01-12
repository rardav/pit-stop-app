namespace PitStop.BusinessLogic.Dtos
{
    public class FixDto
    {
        public int VehicleId { get; set; }

        public int EmployeeId { get; set; }
        
        public string FixedPart { get; set; }

        public DateTime DateOfFixing { get; set; }

        public decimal Price { get; set; }
    }
}
