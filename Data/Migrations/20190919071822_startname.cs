using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareForceOne.Data.Migrations
{
    public partial class startname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TripStartName",
                table: "TripModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripStopName",
                table: "TripModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripStartName",
                table: "TripModel");

            migrationBuilder.DropColumn(
                name: "TripStopName",
                table: "TripModel");
        }
    }
}
