using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSneakers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Stylish relaxed fit OverSized Tees for a comfortable and modern look.", "OverSized Tees", 3500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Rating" },
                values: new object[] { 11, 3, "Stylish relaxed fit Sneakers for a comfortable and modern look.", "  https://images.unsplash.com/photo-1606107557195-0e29a4b5b4aa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8U25lYWtlcnN8ZW58M", "Sneakers Nike", 8000m, 4.5m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Stylish relaxed fit baggy jeans for a comfortable and modern look.", "Baggy Jeans", 4999m });
        }
    }
}
