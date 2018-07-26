using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updatedVehiclesToNotBeADbTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "NumberOfAxels",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "NumberOfPassengers",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "Motorcycles",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motorcycles",
                newName: "Identifier");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Motorcycles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Motorcycles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAxels",
                table: "Motorcycles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPassengers",
                table: "Motorcycles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Motorcycles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Motorcycles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Identifier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    NumberOfAxels = table.Column<int>(nullable: false),
                    NumberOfPassengers = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Identifier);
                });
        }
    }
}
