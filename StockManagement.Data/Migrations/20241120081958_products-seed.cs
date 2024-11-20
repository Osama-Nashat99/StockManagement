using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class productsseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 3, "A high-end smartphone with amazing features", "Smartphone XYZ", 799.00m, 50 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1, "A premium leather jacket for winter", "Stylish Leather Jacket", 120.00m, 30 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 3, 3, "Noise-canceling wireless headphones", "Bluetooth Headphones", 150.00m, 100 },
                    { 4, 1, "A cozy winter jacket to keep you warm", "Winter Jacket", 80.00m, 40 },
                    { 5, 3, "A smartwatch with fitness tracking and notifications", "Smart Watch", 200.00m, 75 },
                    { 6, 3, "Ultra HD LED TV with smart features", "LED TV", 500.00m, 60 },
                    { 7, 4, "Fast boiling electric kettle for quick tea or coffee", "Electric Kettle", 30.00m, 120 },
                    { 8, 4, "Energy-efficient fridge with large capacity", "Refrigerator", 800.00m, 20 },
                    { 9, 3, "Water-resistant portable Bluetooth speaker", "Portable Speaker", 90.00m, 50 },
                    { 10, 4, "Healthy cooking with this modern air fryer", "Air Fryer", 150.00m, 45 },
                    { 11, 4, "Sonic electric toothbrush for cleaner teeth", "Electric Toothbrush", 60.00m, 80 },
                    { 12, 3, "High-quality digital camera for photography enthusiasts", "Digital Camera", 400.00m, 35 },
                    { 13, 3, "Ergonomic gaming mouse with customizable buttons", "Gaming Mouse", 50.00m, 100 },
                    { 14, 4, "Adjustable desk lamp with LED lighting", "LED Desk Lamp", 40.00m, 150 },
                    { 15, 5, "Magnetic phone mount for easy car navigation", "Car Phone Mount", 20.00m, 200 },
                    { 16, 5, "Spacious 4-person camping tent with waterproof design", "Camping Tent", 120.00m, 50 },
                    { 17, 4, "Wi-Fi enabled smart thermostat for energy savings", "Smart Thermostat", 250.00m, 30 },
                    { 18, 3, "High-capacity portable power bank for smartphones", "Portable Charger", 40.00m, 150 },
                    { 19, 1, "Durable and spacious backpack for laptops and accessories", "Laptop Backpack", 40.00m, 80 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 20, "Sleek modern wall clock with a minimal design", "Wall Clock", 25.00m, 120 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 21, 4, "Professional blow dryer with multiple heat settings", "Hair Dryer", 70.00m, 60 },
                    { 22, 4, "Blend your smoothies on the go with this portable blender", "Portable Blender", 45.00m, 75 },
                    { 23, 5, "Portable camping stove for outdoor cooking", "Camping Stove", 70.00m, 40 },
                    { 24, 3, "Wearable fitness tracker to monitor daily activities", "Fitness Tracker", 130.00m, 100 },
                    { 25, 1, "Ergonomic gaming chair with adjustable armrests", "Gaming Chair", 180.00m, 60 },
                    { 26, 5, "Eco-friendly solar charger for your devices", "Solar Charger", 35.00m, 110 },
                    { 27, 4, "Home air purifier with HEPA filter for cleaner air", "Air Purifier", 150.00m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1, "This is a description for the leather waterproof black nice jacket.", "Waterproof Jacket", 86.56m, 5 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 2, "This is a description for the Handmade wallet with this new design.", "Tui Cross Wallet", 26.70m, 2 });
        }
    }
}
