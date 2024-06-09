using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdgeItalianPizza.Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixToppingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_pizza_toppings_toppings_topping_id",
                table: "order_pizza_toppings");

            migrationBuilder.RenameColumn(
                name: "topping_id",
                table: "order_pizza_toppings",
                newName: "topping_details_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_pizza_toppings_topping_id",
                table: "order_pizza_toppings",
                newName: "IX_order_pizza_toppings_topping_details_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_pizza_toppings_topping_details_topping_details_id",
                table: "order_pizza_toppings",
                column: "topping_details_id",
                principalTable: "topping_details",
                principalColumn: "topping_details_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_pizza_toppings_topping_details_topping_details_id",
                table: "order_pizza_toppings");

            migrationBuilder.RenameColumn(
                name: "topping_details_id",
                table: "order_pizza_toppings",
                newName: "topping_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_pizza_toppings_topping_details_id",
                table: "order_pizza_toppings",
                newName: "IX_order_pizza_toppings_topping_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_pizza_toppings_toppings_topping_id",
                table: "order_pizza_toppings",
                column: "topping_id",
                principalTable: "toppings",
                principalColumn: "topping_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
