using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class ProductAddeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Name", "Price", "Quantity", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5409), null, "Elma", 2.5, 100, 1, null },
                    { 2, 1, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5413), null, "Armut", 3.0, 80, 1, null },
                    { 3, 1, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5416), null, "Domates", 1.75, 120, 1, null },
                    { 4, 1, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5418), null, "Salatalık", 1.5, 90, 1, null },
                    { 5, 1, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5420), null, "Portakal", 3.25, 70, 1, null },
                    { 6, 2, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5423), null, "Laptop", 3500.0, 50, 1, null },
                    { 7, 2, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5425), null, "Akıllı Telefon", 2500.0, 80, 1, null },
                    { 8, 2, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5427), null, "Tablet", 1500.0, 60, 1, null },
                    { 9, 2, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5430), null, "Oyun Konsolu", 2000.0, 40, 1, null },
                    { 10, 2, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5432), null, "Kulaklık", 100.0, 200, 1, null },
                    { 11, 3, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5434), null, "Sucuk", 20.0, 30, 1, null },
                    { 12, 3, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5437), null, "Peynir", 15.0, 50, 1, null },
                    { 13, 3, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5439), null, "Zeytin", 10.0, 80, 1, null },
                    { 14, 3, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5442), null, "Bal", 25.0, 40, 1, null },
                    { 15, 3, new DateTime(2024, 7, 6, 16, 24, 37, 429, DateTimeKind.Local).AddTicks(5444), null, "Reçel", 12.0, 60, 1, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 23, 46, 620, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 23, 46, 620, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 6, 16, 23, 46, 620, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
