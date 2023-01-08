using System.ComponentModel.DataAnnotations;

namespace PitStop.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public ICollection<Fix> Fixes { get; set; }
    }
}
