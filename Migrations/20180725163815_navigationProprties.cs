using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class navigationProprties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutomobileId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotorcycleId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AutomobileId",
                table: "WorkOrders",
                column: "AutomobileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MotorcycleId",
                table: "WorkOrders",
                column: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Automobiles_AutomobileId",
                table: "WorkOrders",
                column: "AutomobileId",
                principalTable: "Automobiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Motorcycles_MotorcycleId",
                table: "WorkOrders",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Automobiles_AutomobileId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Motorcycles_MotorcycleId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_AutomobileId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_MotorcycleId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AutomobileId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "WorkOrders");
        }
    }
}
