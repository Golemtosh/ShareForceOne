using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareForceOne.Data.Migrations
{
    public partial class deleteFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "UserViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "UserViewModel",
                nullable: true);
        }
    }
}
