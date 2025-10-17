using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class AddYarnPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YarnPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarpCount = table.Column<string>(type: "text", nullable: false),
                    WarpPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    WeftCount = table.Column<string>(type: "text", nullable: false),
                    WeftPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YarnPrices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YarnPrices");
        }
    }
}
