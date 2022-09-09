using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class removeDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAddresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAddresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
