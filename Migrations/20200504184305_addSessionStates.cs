using Microsoft.EntityFrameworkCore.Migrations;

namespace VirusHackKodShredinger.Migrations
{
    public partial class addSessionStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Sessions");

            migrationBuilder.AddColumn<double>(
                name: "State1",
                table: "Sessions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "State2",
                table: "Sessions",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State1",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "State2",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
