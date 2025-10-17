using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class AddUOMToCountMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "CountMasters",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "CountMasters");
        }
    }
}
