using System.ComponentModel.DataAnnotations;

namespace PitStop.DataAccess.Entities
{
    public class Fix
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string FixedPart { get; set; }

        [Required]
        public DateTime DateOfFixing { get; set; }

        [Required]
        public decimal Price { get; set; }


        public Vehicle Vehicle { get; set; }
        public Employee Employee { get; set; }
    }
}
