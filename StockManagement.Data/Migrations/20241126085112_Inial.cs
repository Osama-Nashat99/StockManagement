using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Role = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StoreKeeperId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_StoreKeeperId",
                        column: x => x.StoreKeeperId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SerialNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssuedFor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin", "admin", "admin", null, null, "AQAAAAIAAYagAAAAEBmmQlp0o9/PqVQcEjJ5oNpr1RxHPVpnOyGBscpUHbSXCl7kzQEVegBMjXDTFM/Ydg==", 1, "admin" },
                    { 2, "admin", "user", "user", null, null, "AQAAAAIAAYagAAAAEGdZtz5RkGhUDdGEeKNmKCJDPTinAGa973qimlZil+OrKHz9o0J/f7c5wgLcsjmOFA==", 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "admin", null, null, "Clothes" },
                    { 2, "admin", null, null, "Accessories" },
                    { 3, "admin", null, null, "Electronics" },
                    { 4, "admin", null, null, "Kitchen" },
                    { 5, "admin", null, null, "Cars" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name", "StoreKeeperId" },
                values: new object[,]
                {
                    { 1, "admin", null, null, "Store 1", 1 },
                    { 2, "admin", null, null, "Store 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "IssuedFor", "ModifiedBy", "ModifiedDate", "Name", "Price", "SerialNumber", "Status", "StoreId" },
                values: new object[,]
                {
                    { 1, 3, "admin", "A high-end smartphone with amazing features", null, null, null, "Smartphone XYZ", 799.00m, "f37d9670-31e3-4f0b-ad73-8796dfb88196", 1, 1 },
                    { 2, 1, "admin", "A premium leather jacket for winter", null, null, null, "Stylish Leather Jacket", 120.00m, "3bd2b3f9-76d0-4a10-ac87-cbe96cf2e36e", 2, 2 },
                    { 3, 3, "admin", "Noise-canceling wireless headphones", null, null, null, "Bluetooth Headphones", 150.00m, "22ff2eac-91b6-4b8c-a914-1b4d67f25e90", 1, 1 },
                    { 4, 1, "admin", "A cozy winter jacket to keep you warm", null, null, null, "Winter Jacket", 80.00m, "c826f33b-832c-4cd3-a39a-c91869a5fcd2", 4, 1 },
                    { 5, 3, "admin", "A smartwatch with fitness tracking and notifications", null, null, null, "Smart Watch", 200.00m, "b47c50f1-6b59-4079-a6f0-5344ba4b9661", 1, 2 },
                    { 6, 3, "admin", "Ultra HD LED TV with smart features", null, null, null, "LED TV", 500.00m, "4833dbe7-e8f1-4b73-be35-dd096c2176d8", 1, 1 },
                    { 7, 4, "admin", "Fast boiling electric kettle for quick tea or coffee", null, null, null, "Electric Kettle", 30.00m, "ce388e1d-a804-48fd-a5b2-2991cba84cad", 4, 2 },
                    { 8, 4, "admin", "Energy-efficient fridge with large capacity", null, null, null, "Refrigerator", 800.00m, "0cf895a8-e50b-47ee-9230-5276a8434ef6", 1, 2 },
                    { 9, 3, "admin", "Water-resistant portable Bluetooth speaker", null, null, null, "Portable Speaker", 90.00m, "774904a8-9b46-484f-87bc-d77a5df82381", 1, 1 },
                    { 10, 4, "admin", "Healthy cooking with this modern air fryer", null, null, null, "Air Fryer", 150.00m, "651271e9-0f22-42d3-b640-c399407eb233", 2, 1 },
                    { 11, 4, "admin", "Sonic electric toothbrush for cleaner teeth", null, null, null, "Electric Toothbrush", 60.00m, "07a3d514-a39f-4eb3-903a-8eac2e4c1aca", 1, 1 },
                    { 12, 3, "admin", "High-quality digital camera for photography enthusiasts", null, null, null, "Digital Camera", 400.00m, "266e73ac-d6ac-405b-93f1-f8314a30684d", 1, 2 },
                    { 13, 3, "admin", "Ergonomic gaming mouse with customizable buttons", "user", null, null, "Gaming Mouse", 50.00m, "dbfff037-2dd6-4984-88d6-b2fae59d2797", 3, 1 },
                    { 14, 4, "admin", "Adjustable desk lamp with LED lighting", null, null, null, "LED Desk Lamp", 40.00m, "8a30c1a3-d4f5-4b7c-98d0-441e845a61ba", 1, 1 },
                    { 15, 5, "admin", "Magnetic phone mount for easy car navigation", null, null, null, "Car Phone Mount", 20.00m, "d73beb2a-7e51-488e-9c16-3e50bc9f9b5d", 1, 1 },
                    { 16, 5, "admin", "Spacious 4-person camping tent with waterproof design", null, null, null, "Camping Tent", 120.00m, "d51cec3a-2a8f-4181-9800-58064a997339", 4, 2 },
                    { 17, 4, "admin", "Wi-Fi enabled smart thermostat for energy savings", null, null, null, "Smart Thermostat", 250.00m, "4b15db37-9f21-424b-9524-21f7b5a4ba7a", 4, 2 },
                    { 18, 3, "admin", "High-capacity portable power bank for smartphones", null, null, null, "Portable Charger", 40.00m, "58fa5abf-4ca2-4a38-ba50-14548992ed67", 2, 1 },
                    { 19, 1, "admin", "Durable and spacious backpack for laptops and accessories", "user", null, null, "Laptop Backpack", 40.00m, "538fa706-0499-4134-af2d-f7c528b40981", 3, 2 },
                    { 20, 1, "admin", "Sleek modern wall clock with a minimal design", null, null, null, "Wall Clock", 25.00m, "76b80998-d196-48c9-ab63-b5369b0bc78a", 1, 1 },
                    { 21, 4, "admin", "Professional blow dryer with multiple heat settings", null, null, null, "Hair Dryer", 70.00m, "77157404-8e16-4ec3-945d-95968641b57e", 1, 2 },
                    { 22, 4, "admin", "Blend your smoothies on the go with this portable blender", "user", null, null, "Portable Blender", 45.00m, "f840d7c8-66ab-40e5-a77b-acc17df90430", 3, 2 },
                    { 23, 5, "admin", "Portable camping stove for outdoor cooking", null, null, null, "Camping Stove", 70.00m, "05ac159d-200b-4293-a40d-3e74b8e800f3", 1, 1 },
                    { 24, 3, "admin", "Wearable fitness tracker to monitor daily activities", null, null, null, "Fitness Tracker", 130.00m, "6c902155-b74b-4e80-9405-4514d79a62eb", 1, 1 },
                    { 25, 1, "admin", "Ergonomic gaming chair with adjustable armrests", "user", null, null, "Gaming Chair", 180.00m, "2f946330-3999-47f6-817e-8d9d840c9e10", 3, 1 },
                    { 26, 5, "admin", "Eco-friendly solar charger for your devices", null, null, null, "Solar Charger", 35.00m, "de1b3592-c371-4d1c-8570-bd7c6078faec", 1, 2 },
                    { 27, 4, "admin", "Home air purifier with HEPA filter for cleaner air", null, null, null, "Air Purifier", 150.00m, "3131938f-c4b3-4a85-b5f9-357eb3c4eb39", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SerialNumber",
                table: "Products",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreKeeperId",
                table: "Stores",
                column: "StoreKeeperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
