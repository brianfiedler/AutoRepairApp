using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dragracer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoseHaveBodykit",
                table: "Tuners",
                newName: "Hasturbo");

            migrationBuilder.AddColumn<bool>(
                name: "HasAirbags",
                table: "Tuners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(                name: "HasBodykit",
                table: "Tuners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSupercharger",
                table: "Tuners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PriorBuildShop",
                table: "Tuners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RacingTeam",
                table: "Tuners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAirbags",
                table: "Tuners");

            migrationBuilder.DropColumn(
                name: "HasBodykit",
                table: "Tuners");

            migrationBuilder.DropColumn(
                name: "HasSupercharger",
                table: "Tuners");

            migrationBuilder.DropColumn(
                name: "PriorBuildShop",
                table: "Tuners");

            migrationBuilder.DropColumn(
                name: "RacingTeam",
                table: "Tuners");

            migrationBuilder.RenameColumn(
                name: "Hasturbo",
                table: "Tuners",
                newName: "DoseHaveBodykit");
        }
    }
}
