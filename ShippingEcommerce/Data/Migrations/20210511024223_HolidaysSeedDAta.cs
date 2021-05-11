using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace ShippingEcommerce.Data.Migrations
{
    public partial class HolidaysSeedDAta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new NodaTime.LocalDate(2021, 1, 1), "New Year's Day" },
                    { 2, new NodaTime.LocalDate(2021, 1, 20), "Birthday of Martin Luther King, Jr." },
                    { 3, new NodaTime.LocalDate(2021, 2, 17), "Presidents' Day" },
                    { 4, new NodaTime.LocalDate(2021, 5, 25), "Memorial Day" },
                    { 5, new NodaTime.LocalDate(2021, 7, 4), "Independence Day" },
                    { 6, new NodaTime.LocalDate(2021, 9, 7), "Labor Day" },
                    { 7, new NodaTime.LocalDate(2021, 10, 12), "Columbus Day" },
                    { 8, new NodaTime.LocalDate(2021, 11, 11), "Veterans Day" },
                    { 9, new NodaTime.LocalDate(2021, 11, 26), "Thanksgiving Day" },
                    { 10, new NodaTime.LocalDate(2021, 12, 25), "Christmas Day" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
