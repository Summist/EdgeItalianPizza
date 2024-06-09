using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdgeItalianPizza.Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountToDateRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "discount",
                table: "promo_codes",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "promo_codes");
        }
    }
}
