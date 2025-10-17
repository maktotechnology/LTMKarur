using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class AddStockWarehouseToItemMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "StockQuantity",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseName",
                table: "ItemMasters",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WarehouseName",
                table: "ItemMasters");
        }
    }
}
