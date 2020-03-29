using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketLab.API.Migrations.MarketLabDb
{
    public partial class marketlab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 731, DateTimeKind.Local).AddTicks(9530), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7890), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7930), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7940), new DateTime(2020, 3, 29, 8, 12, 24, 737, DateTimeKind.Local).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 8, 12, 24, 739, DateTimeKind.Local).AddTicks(1500), new DateTime(2020, 3, 29, 8, 12, 24, 739, DateTimeKind.Local).AddTicks(1510) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ListingId",
                table: "ShoppingListItems",
                column: "ListingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_Listings_ListingId",
                table: "ShoppingListItems",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_Listings_ListingId",
                table: "ShoppingListItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_ListingId",
                table: "ShoppingListItems");

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 976, DateTimeKind.Local).AddTicks(610), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2850), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2890), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2890), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2900), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2900), new DateTime(2020, 3, 29, 7, 42, 34, 982, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 29, 7, 42, 34, 983, DateTimeKind.Local).AddTicks(7140), new DateTime(2020, 3, 29, 7, 42, 34, 983, DateTimeKind.Local).AddTicks(7150) });
        }
    }
}
