using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class MoveCategoriesSeedToSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(506), "Dog food" },
                    { 2, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(548), "Cat food" },
                    { 3, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(552), "Rabbit food" },
                    { 4, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(554), "Bird food" },
                    { 5, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(557), "Fish food" },
                    { 6, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(560), "Dog toys" },
                    { 7, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(563), "Cat toys" },
                    { 8, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(566), "Rabbit cages" },
                    { 9, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(569), "Transport" },
                    { 10, new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(572), "Bird cage" }
                });
        }
    }
}
