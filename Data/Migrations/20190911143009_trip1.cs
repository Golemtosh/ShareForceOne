using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareForceOne.Data.Migrations
{
    public partial class trip1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripModel",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripCarId = table.Column<int>(nullable: false),
                    TripStartCoord = table.Column<string>(nullable: true),
                    TripStopCoord = table.Column<string>(nullable: true),
                    TripCreator = table.Column<string>(nullable: true),
                    TripKMCost = table.Column<decimal>(nullable: false),
                    TripDateTime = table.Column<DateTime>(nullable: false),
                    TripCarSeats = table.Column<int>(nullable: false),
                    TripAnimals = table.Column<int>(nullable: false),
                    TripInfoText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripModel", x => x.TripId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripModel");
        }
    }
}
