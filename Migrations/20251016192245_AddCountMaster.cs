using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LTMKarur.Migrations
{
    /// <inheritdoc />
    public partial class AddCountMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountMasters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountMasters");
        }
    }
}
