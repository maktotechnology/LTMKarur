using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WarpCountId = table.Column<int>(type: "integer", nullable: true),
                    WeftCountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMasters_CountMasters_WarpCountId",
                        column: x => x.WarpCountId,
                        principalTable: "CountMasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemMasters_CountMasters_WeftCountId",
                        column: x => x.WeftCountId,
                        principalTable: "CountMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_WarpCountId",
                table: "ItemMasters",
                column: "WarpCountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_WeftCountId",
                table: "ItemMasters",
                column: "WeftCountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMasters");
        }
    }
}
