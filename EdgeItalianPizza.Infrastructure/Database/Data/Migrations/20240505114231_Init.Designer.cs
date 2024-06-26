﻿// <auto-generated />
using System;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EdgeItalianPizza.Infrastructure.Database.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240505114231_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BonusCoins")
                        .HasColumnType("int")
                        .HasColumnName("bonus_coins");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.HasKey("Id");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_of_created");

                    b.Property<long?>("customer_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("promo_code_id")
                        .HasColumnType("bigint");

                    b.Property<long>("restaurant_id")
                        .HasColumnType("bigint");

                    b.Property<long>("status_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("customer_id");

                    b.HasIndex("promo_code_id");

                    b.HasIndex("restaurant_id");

                    b.HasIndex("status_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderDrink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("order_drink_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("Amount")
                        .HasColumnType("tinyint")
                        .HasColumnName("amount");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("smallmoney")
                        .HasColumnName("unit_price");

                    b.Property<long>("drink_id")
                        .HasColumnType("bigint");

                    b.Property<long>("order_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("drink_id");

                    b.HasIndex("order_id");

                    b.ToTable("orders_drinks", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderPizza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("order_pizza_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("Amount")
                        .HasColumnType("tinyint")
                        .HasColumnName("amount");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("smallmoney")
                        .HasColumnName("unit_price");

                    b.Property<long>("order_id")
                        .HasColumnType("bigint");

                    b.Property<long>("pizza_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("order_id");

                    b.HasIndex("pizza_id");

                    b.ToTable("orders_pizzas", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderPizzaToppings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("order_pizza_topping_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("order_pizza_id")
                        .HasColumnType("bigint");

                    b.Property<long>("topping_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("order_pizza_id");

                    b.HasIndex("topping_id");

                    b.ToTable("order_pizza_toppings", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.PromoCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("promo_code_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("code");

                    b.HasKey("Id");

                    b.ToTable("promo_codes", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("status_name");

                    b.HasKey("Id");

                    b.ToTable("statuses", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Drink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("drink_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("PhotoUri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("photo_uri");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("price");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("drinks", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Pizza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("pizza_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("PhotoUri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("photo_uri");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("price");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.Property<long>("size_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.HasIndex("size_id");

                    b.ToTable("pizzas", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("product_name");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Size", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("size_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("size_name");

                    b.Property<short>("Value")
                        .HasColumnType("smallint")
                        .HasColumnName("size_value");

                    b.HasKey("Id");

                    b.ToTable("sizes", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Topping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("topping_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("topping_name");

                    b.Property<string>("PhotoUri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("photo_uri");

                    b.HasKey("Id");

                    b.ToTable("toppings", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.ToppingDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("topping_details_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("price");

                    b.Property<long>("size_id")
                        .HasColumnType("bigint");

                    b.Property<long>("topping_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("size_id");

                    b.HasIndex("topping_id");

                    b.ToTable("topping_details", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Restaurants.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("city_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city_name");

                    b.HasKey("Id");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Restaurants.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("restaurant_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("city_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("city_id");

                    b.ToTable("restaurants", (string)null);
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Customers.Customer", b =>
                {
                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Customers.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<long>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("HashValue")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("password_hash");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Customers.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<long>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)")
                                .HasColumnName("phone_number");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("customer_id");

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Orders.PromoCode", "PromoCode")
                        .WithMany("Orders")
                        .HasForeignKey("promo_code_id");

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Restaurants.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("restaurant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Orders.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Orders.ValueObjects.Code", "Code", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("code");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Code")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PromoCode");

                    b.Navigation("Restaurant");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderDrink", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("drink_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderPizza", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("pizza_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderPizzaToppings", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Orders.OrderPizza", "Pizza")
                        .WithMany("Toppings")
                        .HasForeignKey("order_pizza_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Topping", "Topping")
                        .WithMany("Pizzas")
                        .HasForeignKey("topping_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.PromoCode", b =>
                {
                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Orders.ValueObjects.DateRange", "Period", b1 =>
                        {
                            b1.Property<long>("PromoCodeId")
                                .HasColumnType("bigint");

                            b1.Property<DateOnly>("DateEnd")
                                .HasColumnType("DATE")
                                .HasColumnName("date_end");

                            b1.Property<DateOnly>("DateStart")
                                .HasColumnType("DATE")
                                .HasColumnName("date_start");

                            b1.HasKey("PromoCodeId");

                            b1.ToTable("promo_codes");

                            b1.WithOwner()
                                .HasForeignKey("PromoCodeId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Drink", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Product", "Product")
                        .WithMany("Drinks")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Products.ValueObjects.NutritionalValue", "NutritionalValue", b1 =>
                        {
                            b1.Property<long>("DrinkId")
                                .HasColumnType("bigint");

                            b1.Property<decimal?>("Carbs")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("carbs");

                            b1.Property<decimal?>("Fats")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("fats");

                            b1.Property<decimal?>("Kcal")
                                .HasColumnType("decimal(4, 1)")
                                .HasColumnName("kcal");

                            b1.Property<decimal>("Portion")
                                .HasColumnType("decimal(4, 1)")
                                .HasColumnName("volume");

                            b1.Property<decimal?>("Proteins")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("proteins");

                            b1.HasKey("DrinkId");

                            b1.ToTable("drinks");

                            b1.WithOwner()
                                .HasForeignKey("DrinkId");
                        });

                    b.Navigation("NutritionalValue")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Pizza", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Product", "Product")
                        .WithMany("Pizzas")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("size_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Products.ValueObjects.NutritionalValue", "NutritionalValue", b1 =>
                        {
                            b1.Property<long>("PizzaId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Carbs")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("carbs");

                            b1.Property<decimal>("Fats")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("fats");

                            b1.Property<decimal>("Kcal")
                                .HasColumnType("decimal(4, 1)")
                                .HasColumnName("kcal");

                            b1.Property<decimal>("Portion")
                                .HasColumnType("decimal(4, 1)")
                                .HasColumnName("weight");

                            b1.Property<decimal>("Proteins")
                                .HasColumnType("decimal(3, 1)")
                                .HasColumnName("proteins");

                            b1.HasKey("PizzaId");

                            b1.ToTable("pizzas");

                            b1.WithOwner()
                                .HasForeignKey("PizzaId");
                        });

                    b.Navigation("NutritionalValue")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.ToppingDetails", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Size", "Size")
                        .WithMany("ToppingDetails")
                        .HasForeignKey("size_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EdgeItalianPizza.Domain.Entities.Products.Topping", "Topping")
                        .WithMany("ToppingDetails")
                        .HasForeignKey("topping_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Size");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Restaurants.Restaurant", b =>
                {
                    b.HasOne("EdgeItalianPizza.Domain.Entities.Restaurants.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("city_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("RestaurantId")
                                .HasColumnType("bigint");

                            b1.Property<string>("HouseNumber")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("house_number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("street");

                            b1.HasKey("RestaurantId");

                            b1.ToTable("restaurants");

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");
                        });

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects.Login", "Login", b1 =>
                        {
                            b1.Property<long>("RestaurantId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)")
                                .HasColumnName("login");

                            b1.HasKey("RestaurantId");

                            b1.ToTable("restaurants");

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");
                        });

                    b.OwnsOne("EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<long>("RestaurantId")
                                .HasColumnType("bigint");

                            b1.Property<string>("HashValue")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("password_hash");

                            b1.HasKey("RestaurantId");

                            b1.ToTable("restaurants");

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.OrderPizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.PromoCode", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Orders.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("Drinks");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Size", b =>
                {
                    b.Navigation("Pizzas");

                    b.Navigation("ToppingDetails");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Products.Topping", b =>
                {
                    b.Navigation("Pizzas");

                    b.Navigation("ToppingDetails");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Restaurants.City", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("EdgeItalianPizza.Domain.Entities.Restaurants.Restaurant", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
