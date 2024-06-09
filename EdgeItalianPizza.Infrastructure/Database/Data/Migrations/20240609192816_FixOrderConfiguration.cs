using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdgeItalianPizza.Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "bonus_coins",
                table: "orders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bonus_coins",
                table: "orders");
        }
    }
}
