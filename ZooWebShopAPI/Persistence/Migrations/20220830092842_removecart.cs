using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class removecart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 8, 30, 11, 28, 41, 701, DateTimeKind.Local).AddTicks(572));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 8, 25, 21, 19, 50, 38, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_UserId",
                table: "CartProducts",
                column: "UserId");
        }
    }
}
