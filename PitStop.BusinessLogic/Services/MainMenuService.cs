using PitStop.BusinessLogic.Contracts;
using PitStop.DataAccess.Entities;
using System.Text;

namespace PitStop.BusinessLogic.Services
{
    public class MainMenuService : IMainMenuService
    {
        public StringBuilder GetFixString(Fix fix)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(fix.DateOfFixing.ToString("dd/MM/yyyy"));
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Employee.FirstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Employee.LastName);
            stringBuilder.Append(" \t=>\t ");
            stringBuilder.Append(fix.Vehicle.Manufacturer);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Vehicle.Model);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Vehicle.PlateNumber);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.FixedPart);
            stringBuilder.Append(" \t-\t");
            stringBuilder.Append(fix.Vehicle.Client.FirstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(fix.Vehicle.Client.LastName);

            return stringBuilder;
        }
    }
}
