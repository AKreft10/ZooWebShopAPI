using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class UserCartReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 8, 25, 19, 31, 19, 891, DateTimeKind.Local).AddTicks(8999));
        }
    }
}
