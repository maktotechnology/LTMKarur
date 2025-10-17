using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemMasterForCounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMasters_CountMasters_WarpCountId",
                table: "ItemMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMasters_CountMasters_WeftCountId",
                table: "ItemMasters");

            migrationBuilder.DropIndex(
                name: "IX_ItemMasters_WarpCountId",
                table: "ItemMasters");

            migrationBuilder.DropIndex(
                name: "IX_ItemMasters_WeftCountId",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WarpCountId",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WeftCountId",
                table: "ItemMasters");

            migrationBuilder.AddColumn<decimal>(
                name: "Crimp",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Dent",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Design",
                table: "ItemMasters",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EndsPerDent",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GSM",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Input",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReadOnLoom",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarpCount",
                table: "ItemMasters",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WarpEndsPerBeam",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WarpWeight",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeftCount",
                table: "ItemMasters",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "ItemMasters",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crimp",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "Dent",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "EPI",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "EndsPerDent",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "GSM",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "Input",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "PPI",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "ReadOnLoom",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WarpCount",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WarpEndsPerBeam",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WarpWeight",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "WeftCount",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ItemMasters");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ItemMasters",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WarpCountId",
                table: "ItemMasters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeftCountId",
                table: "ItemMasters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_WarpCountId",
                table: "ItemMasters",
                column: "WarpCountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_WeftCountId",
                table: "ItemMasters",
                column: "WeftCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMasters_CountMasters_WarpCountId",
                table: "ItemMasters",
                column: "WarpCountId",
                principalTable: "CountMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMasters_CountMasters_WeftCountId",
                table: "ItemMasters",
                column: "WeftCountId",
                principalTable: "CountMasters",
                principalColumn: "Id");
        }
    }
}
