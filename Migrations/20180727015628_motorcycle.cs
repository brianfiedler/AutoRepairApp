using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class motorcycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Motorcycles",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Motorcycles");

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
        }
    }
}
