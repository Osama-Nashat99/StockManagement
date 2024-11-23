using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, "Clothes" },
                    { 2, null, null, null, "Accessories" },
                    { 3, null, null, null, "Electronics" },
                    { 4, null, null, null, "Kitchen" },
                    { 5, null, null, null, "Cars" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "ModifiedBy", "ModifiedDate", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, "admin123", "Admin", "admin" },
                    { 2, null, null, null, "user123", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "ModifiedBy", "ModifiedDate", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 3, null, "A high-end smartphone with amazing features", null, null, "Smartphone XYZ", 799.00m, 50 },
                    { 2, 1, null, "A premium leather jacket for winter", null, null, "Stylish Leather Jacket", 120.00m, 30 },
                    { 3, 3, null, "Noise-canceling wireless headphones", null, null, "Bluetooth Headphones", 150.00m, 100 },
                    { 4, 1, null, "A cozy winter jacket to keep you warm", null, null, "Winter Jacket", 80.00m, 40 },
                    { 5, 3, null, "A smartwatch with fitness tracking and notifications", null, null, "Smart Watch", 200.00m, 75 },
                    { 6, 3, null, "Ultra HD LED TV with smart features", null, null, "LED TV", 500.00m, 60 },
                    { 7, 4, null, "Fast boiling electric kettle for quick tea or coffee", null, null, "Electric Kettle", 30.00m, 120 },
                    { 8, 4, null, "Energy-efficient fridge with large capacity", null, null, "Refrigerator", 800.00m, 20 },
                    { 9, 3, null, "Water-resistant portable Bluetooth speaker", null, null, "Portable Speaker", 90.00m, 50 },
                    { 10, 4, null, "Healthy cooking with this modern air fryer", null, null, "Air Fryer", 150.00m, 45 },
                    { 11, 4, null, "Sonic electric toothbrush for cleaner teeth", null, null, "Electric Toothbrush", 60.00m, 80 },
                    { 12, 3, null, "High-quality digital camera for photography enthusiasts", null, null, "Digital Camera", 400.00m, 35 },
                    { 13, 3, null, "Ergonomic gaming mouse with customizable buttons", null, null, "Gaming Mouse", 50.00m, 100 },
                    { 14, 4, null, "Adjustable desk lamp with LED lighting", null, null, "LED Desk Lamp", 40.00m, 150 },
                    { 15, 5, null, "Magnetic phone mount for easy car navigation", null, null, "Car Phone Mount", 20.00m, 200 },
                    { 16, 5, null, "Spacious 4-person camping tent with waterproof design", null, null, "Camping Tent", 120.00m, 50 },
                    { 17, 4, null, "Wi-Fi enabled smart thermostat for energy savings", null, null, "Smart Thermostat", 250.00m, 30 },
                    { 18, 3, null, "High-capacity portable power bank for smartphones", null, null, "Portable Charger", 40.00m, 150 },
                    { 19, 1, null, "Durable and spacious backpack for laptops and accessories", null, null, "Laptop Backpack", 40.00m, 80 },
                    { 20, 1, null, "Sleek modern wall clock with a minimal design", null, null, "Wall Clock", 25.00m, 120 },
                    { 21, 4, null, "Professional blow dryer with multiple heat settings", null, null, "Hair Dryer", 70.00m, 60 },
                    { 22, 4, null, "Blend your smoothies on the go with this portable blender", null, null, "Portable Blender", 45.00m, 75 },
                    { 23, 5, null, "Portable camping stove for outdoor cooking", null, null, "Camping Stove", 70.00m, 40 },
                    { 24, 3, null, "Wearable fitness tracker to monitor daily activities", null, null, "Fitness Tracker", 130.00m, 100 },
                    { 25, 1, null, "Ergonomic gaming chair with adjustable armrests", null, null, "Gaming Chair", 180.00m, 60 },
                    { 26, 5, null, "Eco-friendly solar charger for your devices", null, null, "Solar Charger", 35.00m, 110 },
                    { 27, 4, null, "Home air purifier with HEPA filter for cleaner air", null, null, "Air Purifier", 150.00m, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
