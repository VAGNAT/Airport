using Microsoft.EntityFrameworkCore.Migrations;

namespace Airport.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Planes");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "AirCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "AirCompanies");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
