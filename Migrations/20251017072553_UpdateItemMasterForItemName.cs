using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemMasterForItemName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "ItemMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WeftCount",
                table: "ItemMasters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WarpCount",
                table: "ItemMasters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Design",
                table: "ItemMasters",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "ItemMasters",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "WeftCount",
                table: "ItemMasters",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "WarpCount",
                table: "ItemMasters",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "PPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "EPI",
                table: "ItemMasters",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Design",
                table: "ItemMasters",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
