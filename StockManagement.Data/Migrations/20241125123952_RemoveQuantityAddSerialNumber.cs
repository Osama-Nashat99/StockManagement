using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuantityAddSerialNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "SerialNumber",
                value: "5a5d2376-c23a-4455-b388-8e36ae2ccfc6");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "SerialNumber",
                value: "0f9bac5c-a46b-403a-8a68-39ee78d1409f");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "SerialNumber",
                value: "fcb71ce4-25d0-4031-9053-eadca828ec6e");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "SerialNumber",
                value: "a3f0a58f-7400-43ee-856a-5c8ebe901be9");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "SerialNumber",
                value: "36e3f9c5-e5b9-4f16-959b-a2bcdc76d701");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "SerialNumber",
                value: "b7483350-cce4-4f04-b9a4-443d16df038c");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "SerialNumber",
                value: "50dc923f-c588-48a6-b981-4781f90a17d6");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "SerialNumber",
                value: "e3b7d25f-5277-4e07-850f-8b9ff4855a36");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "SerialNumber",
                value: "8386f46f-3403-4196-a1cd-404722bf7d91");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "SerialNumber",
                value: "4db3ff0f-07ab-42f7-a0d2-6e95a13215a8");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "SerialNumber",
                value: "c138a585-3959-428b-8c1b-e75e6a9698b6");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "SerialNumber",
                value: "e2730a18-0e01-4e6b-8b19-fa4c1be2f491");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "SerialNumber",
                value: "72a6e83c-a5e1-4d62-a3db-3792ab30fda7");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "SerialNumber",
                value: "13d2eeaa-a58f-4273-a283-004a1c87a364");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "SerialNumber",
                value: "c696ada0-c36c-4093-b628-3cf22475fc60");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "SerialNumber",
                value: "7be829fb-1003-421f-bfda-cb1b46a2b718");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "SerialNumber",
                value: "4ffd8cbc-b5bd-42f2-bba0-47268e379132");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "SerialNumber",
                value: "4f3f75dc-fd87-4468-b1c7-a550b7516aea");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "SerialNumber",
                value: "f76ef7ff-240a-4989-b7d8-c3575939a808");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "SerialNumber",
                value: "76881290-6c05-495a-8160-027bffd4323f");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "SerialNumber",
                value: "b55dc73f-d093-4af1-bb0a-dd0ca4abf9f0");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "SerialNumber",
                value: "1f7a46b6-131f-4454-aa08-f091a5b7980b");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "SerialNumber",
                value: "7cdea6eb-d8a5-4db9-b133-a823fd29a593");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "SerialNumber",
                value: "cc02b812-8602-47ae-9d84-9093ba430e4b");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "SerialNumber",
                value: "c8e7458e-a7e3-4beb-9650-6322e7f21b43");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "SerialNumber",
                value: "a3c6fc60-5e39-4585-b209-c57e5a78e1c5");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "SerialNumber",
                value: "eab010d3-1af2-465e-8c74-8a2b1cc4eab8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEDum2iRiutnvrIxksx260617eJZ5/frmQHNpcaEP27j39MWIxPKHhv2ntx5/nfMeTw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEKdGQFx6nUc7WD3b5LU2dBKnJm0+JoJeT386V26RG+9LtONU47329rCacuooACFtnQ==");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SerialNumber",
                table: "Products",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_SerialNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Quantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Quantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMWCsWXMB6pQR19hYOn2kH10bkv7Z8S+onHAVRuwrSIRQCasriJyD/ygGb/BIpc6Ig==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEOxpjpkjDJgvOtgjUUSz45heA7vI2dfx7hKN+raYatQGtanFM+L7WusgiRyU/uiHIA==");
        }
    }
}
