using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class updateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate" },
                values: new object[] { new DateTime(2024, 7, 4, 9, 31, 37, 459, DateTimeKind.Local).AddTicks(9906), null });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DeletedDate" },
                values: new object[] { new DateTime(2024, 7, 4, 9, 31, 37, 459, DateTimeKind.Local).AddTicks(9916), null });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DeletedDate" },
                values: new object[] { new DateTime(2024, 7, 4, 9, 31, 37, 459, DateTimeKind.Local).AddTicks(9917), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4175));
        }
    }
}
