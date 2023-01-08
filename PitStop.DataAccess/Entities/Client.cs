using System.ComponentModel.DataAnnotations;

namespace PitStop.DataAccess.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
