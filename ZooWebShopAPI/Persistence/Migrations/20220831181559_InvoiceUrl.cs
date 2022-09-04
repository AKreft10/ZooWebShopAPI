using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooWebShopAPI.Migrations
{
    public partial class InvoiceUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceUrl",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceUrl",
                table: "Orders");
        }
    }
}
