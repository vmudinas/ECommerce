using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingEcommerce.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "InventoryQuantity", "MaxBusinessDaysToShip", "ProductName", "ShipOnWeekends" },
                values: new object[,]
                {
                    { 1, 43, 13, "fugiat exercitation adipisicing", true },
                    { 2, 70, 18, "mollit cupidatat Lorem", true },
                    { 3, 33, 15, "non quis sint", false },
                    { 4, 52, 18, "voluptate cupidatat non", false },
                    { 5, 39, 19, "anim amet occaecat", true },
                    { 6, 47, 20, "cillum deserunt elit", false },
                    { 7, 71, 15, "adipisicing reprehenderit et", false },
                    { 8, 80, 15, "ex mollit laboris", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);
        }
    }
}
