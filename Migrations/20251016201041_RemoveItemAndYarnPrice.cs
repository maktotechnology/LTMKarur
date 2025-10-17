using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTMKarur.Migrations
{
    public partial class RemoveItemAndYarnPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Safely drop both tables only if they exist
            migrationBuilder.Sql(@"DROP TABLE IF EXISTS ""Items"" CASCADE;");
            migrationBuilder.Sql(@"DROP TABLE IF EXISTS ""YarnPrices"" CASCADE;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optional - you can leave this empty
        }
    }
}
