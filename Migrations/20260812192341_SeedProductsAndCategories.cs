using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopHub.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Fashion" },
                    { 3, "Shoes" },
                    { 4, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Latest Apple smartphone with powerful performance.", "https://images.unsplash.com/photo-1592899677977-9c10ca588bbd", "iPhone 15", 199999m, 4.8m },
                    { 2, 1, "Lightweight laptop with excellent performance.", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8", "MacBook Air", 289999m, 4.9m },
                    { 3, 1, "Premium wireless headphones with clear sound.", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e", "Sony Headphones", 45999m, 4.7m },
                    { 4, 2, "Comfortable premium cotton hoodie.", "https://images.unsplash.com/photo-1556821840-3a63f95609a7", "Classic Hoodie", 5999m, 4.5m },
                    { 5, 2, "Classic denim jacket for everyday style.", "https://images.unsplash.com/photo-1551028719-00167b16eac5", "Denim Jacket", 7999m, 4.6m },
                    { 6, 3, "Comfortable sneakers designed for everyday use.", "https://images.unsplash.com/photo-1542291026-7eec264c27ff", "Nike Air Max", 24999m, 4.8m },
                    { 7, 4, "Premium genuine leather wallet.", "https://images.unsplash.com/photo-1627123424574-724758594e93", "Leather Wallet", 3499m, 4.4m },
                    { 8, 4, "Elegant watch suitable for casual and formal wear.", "https://images.unsplash.com/photo-1524805444758-089113d48a6d", "Classic Watch", 12999m, 4.7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
