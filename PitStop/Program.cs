using PitStop.DataAccess.Context;
using PitStop.DataAccess.Entities;


using var context = new PitStopContext();

context.Database.EnsureCreated();

var vehicle = new Vehicle
{
    Manufacturer = "Ford",
    Model = "EcoSport",
    Year = 2020,
    PlateNumber = "B100ZXS"
};

context.Vehicles.Add(vehicle);
context.SaveChanges();

foreach (var veh in context.Vehicles)
{
    Console.WriteLine(vehicle.Model);
}