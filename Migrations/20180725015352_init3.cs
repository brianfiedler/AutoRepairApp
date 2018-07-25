using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RideHigh",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    Identifier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfAxels = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    NumberOfPassengers = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    RideHigh = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.Identifier);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RideHigh",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }
    }
}
