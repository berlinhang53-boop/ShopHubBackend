using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBaggyJeans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Rating" },
                values: new object[] { 9, 2, "Stylish relaxed fit baggy jeans for a comfortable and modern look.", "https://images.unsplash.com/photo-1674075872359-a174bc7ed420?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8QmFnZ3klMjBqZWFuc3xlbnwwfHwwfHx8MA%3D%3D", "Baggy Jeans", 4999m, 4.5m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
