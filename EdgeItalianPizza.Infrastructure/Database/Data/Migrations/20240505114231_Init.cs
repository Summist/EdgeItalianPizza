using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdgeItalianPizza.Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    bonus_coins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "promo_codes",
                columns: table => new
                {
                    promo_code_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_start = table.Column<DateOnly>(type: "DATE", nullable: false),
                    date_end = table.Column<DateOnly>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promo_codes", x => x.promo_code_id);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    size_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    size_value = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.size_id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    status_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "toppings",
                columns: table => new
                {
                    topping_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_uri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    topping_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toppings", x => x.topping_id);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    restaurant_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<long>(type: "bigint", nullable: false),
                    login = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    house_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.restaurant_id);
                    table.ForeignKey(
                        name: "FK_restaurants_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    drink_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    photo_uri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    kcal = table.Column<decimal>(type: "decimal(4,1)", nullable: true),
                    proteins = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    fats = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    carbs = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    volume = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    price = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.drink_id);
                    table.ForeignKey(
                        name: "FK_drinks_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pizzas",
                columns: table => new
                {
                    pizza_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    size_id = table.Column<long>(type: "bigint", nullable: false),
                    photo_uri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    kcal = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    proteins = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    fats = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    carbs = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    price = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzas", x => x.pizza_id);
                    table.ForeignKey(
                        name: "FK_pizzas_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_pizzas_sizes_size_id",
                        column: x => x.size_id,
                        principalTable: "sizes",
                        principalColumn: "size_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topping_details",
                columns: table => new
                {
                    topping_details_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topping_id = table.Column<long>(type: "bigint", nullable: false),
                    size_id = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topping_details", x => x.topping_details_id);
                    table.ForeignKey(
                        name: "FK_topping_details_sizes_size_id",
                        column: x => x.size_id,
                        principalTable: "sizes",
                        principalColumn: "size_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topping_details_toppings_topping_id",
                        column: x => x.topping_id,
                        principalTable: "toppings",
                        principalColumn: "topping_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    restaurant_id = table.Column<long>(type: "bigint", nullable: false),
                    promo_code_id = table.Column<long>(type: "bigint", nullable: true),
                    status_id = table.Column<long>(type: "bigint", nullable: false),
                    date_of_created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_orders_promo_codes_promo_code_id",
                        column: x => x.promo_code_id,
                        principalTable: "promo_codes",
                        principalColumn: "promo_code_id");
                    table.ForeignKey(
                        name: "FK_orders_restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "restaurants",
                        principalColumn: "restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders_drinks",
                columns: table => new
                {
                    order_drink_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    drink_id = table.Column<long>(type: "bigint", nullable: false),
                    unit_price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    amount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_drinks", x => x.order_drink_id);
                    table.ForeignKey(
                        name: "FK_orders_drinks_drinks_drink_id",
                        column: x => x.drink_id,
                        principalTable: "drinks",
                        principalColumn: "drink_id");
                    table.ForeignKey(
                        name: "FK_orders_drinks_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders_pizzas",
                columns: table => new
                {
                    order_pizza_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    pizza_id = table.Column<long>(type: "bigint", nullable: false),
                    unit_price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    amount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_pizzas", x => x.order_pizza_id);
                    table.ForeignKey(
                        name: "FK_orders_pizzas_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_pizzas_pizzas_pizza_id",
                        column: x => x.pizza_id,
                        principalTable: "pizzas",
                        principalColumn: "pizza_id");
                });

            migrationBuilder.CreateTable(
                name: "order_pizza_toppings",
                columns: table => new
                {
                    order_pizza_topping_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_pizza_id = table.Column<long>(type: "bigint", nullable: false),
                    topping_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_pizza_toppings", x => x.order_pizza_topping_id);
                    table.ForeignKey(
                        name: "FK_order_pizza_toppings_orders_pizzas_order_pizza_id",
                        column: x => x.order_pizza_id,
                        principalTable: "orders_pizzas",
                        principalColumn: "order_pizza_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_pizza_toppings_toppings_topping_id",
                        column: x => x.topping_id,
                        principalTable: "toppings",
                        principalColumn: "topping_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinks_product_id",
                table: "drinks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_pizza_toppings_order_pizza_id",
                table: "order_pizza_toppings",
                column: "order_pizza_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_pizza_toppings_topping_id",
                table: "order_pizza_toppings",
                column: "topping_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_promo_code_id",
                table: "orders",
                column: "promo_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_restaurant_id",
                table: "orders",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_status_id",
                table: "orders",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_drinks_drink_id",
                table: "orders_drinks",
                column: "drink_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_drinks_order_id",
                table: "orders_drinks",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_pizzas_order_id",
                table: "orders_pizzas",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_pizzas_pizza_id",
                table: "orders_pizzas",
                column: "pizza_id");

            migrationBuilder.CreateIndex(
                name: "IX_pizzas_product_id",
                table: "pizzas",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pizzas_size_id",
                table: "pizzas",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_city_id",
                table: "restaurants",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_topping_details_size_id",
                table: "topping_details",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "IX_topping_details_topping_id",
                table: "topping_details",
                column: "topping_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_pizza_toppings");

            migrationBuilder.DropTable(
                name: "orders_drinks");

            migrationBuilder.DropTable(
                name: "topping_details");

            migrationBuilder.DropTable(
                name: "orders_pizzas");

            migrationBuilder.DropTable(
                name: "drinks");

            migrationBuilder.DropTable(
                name: "toppings");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "pizzas");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "promo_codes");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
