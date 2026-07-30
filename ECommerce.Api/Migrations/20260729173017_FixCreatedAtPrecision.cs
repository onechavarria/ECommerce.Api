using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixCreatedAtPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAd",
                table: "Products",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "CreatedAd");
        }
    }
}
