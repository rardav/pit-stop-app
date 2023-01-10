using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitStop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class vehicleTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutomaticGearbox",
                table: "Vehicles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NoOfSeats",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Vehicles",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutomaticGearbox",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NoOfSeats",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Vehicles");
        }
    }
}
