using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WarpCount = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WeftCount = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EndsPerInch = table.Column<int>(type: "integer", nullable: false),
                    PicksPerInch = table.Column<int>(type: "integer", nullable: false),
                    Design = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Width = table.Column<decimal>(type: "numeric", nullable: false),
                    Crimp = table.Column<decimal>(type: "numeric", nullable: true),
                    ReadOnLoom = table.Column<decimal>(type: "numeric", nullable: true),
                    Dent = table.Column<decimal>(type: "numeric", nullable: true),
                    WarpEndsPerBeam = table.Column<int>(type: "integer", nullable: true),
                    WarpWeight = table.Column<decimal>(type: "numeric", nullable: true),
                    EndsPerDent = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
