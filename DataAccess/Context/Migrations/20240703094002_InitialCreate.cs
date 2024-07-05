﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4158), "Sebze ve Meyve ürünleri bulunur", "Manav", 1, null },
                    { 2, new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4174), "Teknolojik ürünler bulunur", "Teknoloji", 1, null },
                    { 3, new DateTime(2024, 7, 3, 12, 40, 1, 866, DateTimeKind.Local).AddTicks(4175), "Kahvaltılık ürünler bulunur", "Şarküteri", 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
