using System.ComponentModel.DataAnnotations;

namespace PitStop.DataAccess.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public int ClientId { get; set; }


        public Client Client { get; set; }
        public ICollection<Fix> Fixes { get; set; }

    }
}
