using Microsoft.EntityFrameworkCore;
using PitStop.DataAccess.Entities;

namespace PitStop.DataAccess.Context
{
    public class PitStopContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Fix> Fixes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PitStopDatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var employees = new Employee[]
            {
                new Employee
                {
                    Id= 1,
                    FirstName = "Cezin",
                    LastName = "Cupii"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Rares",
                    LastName = "David"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Vlad",
                    LastName = "Gont"
                }
            };

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
