using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class CartCartProductListReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 41, 40, 785, DateTimeKind.Local).AddTicks(7718));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 37, 53, 219, DateTimeKind.Local).AddTicks(9830));
        }
    }
}
