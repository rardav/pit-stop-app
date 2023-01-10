using PitStop.DataAccess.Context;


using var context = new PitStopContext();

context.Database.EnsureCreated();

