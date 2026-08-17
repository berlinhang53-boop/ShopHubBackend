using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopHub.API.Migrations
{
    /// <inheritdoc />
    public partial class OverSizedTeesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Rating" },
                values: new object[] { 10, 2, "Stylish relaxed fit baggy jeans for a comfortable and modern look.", " https://plus.unsplash.com/premium_photo-1673356301535-2cc45bcc79e4?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fE92ZXIlMjBzaXplZCUyMHRlZXN8ZW58MHx8MHx8fDA%3D\r\n", "Baggy Jeans", 4999m, 4.5m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
