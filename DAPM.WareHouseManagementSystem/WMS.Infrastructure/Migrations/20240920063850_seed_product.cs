using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedBy", "CreatedOn", "Description", "Discontinued", "ModifiedBy", "ModifiedOn", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6830), null, false, null, null, "Sony Bravia QLED SQ101", null, 10000000.0 },
                    { 2, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6849), null, false, null, null, "Sony Bravia OLED SN101", null, 15000000.0 },
                    { 3, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6851), null, false, null, null, "Sam Sung QLED SSQ113", null, 12000000.0 },
                    { 4, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6852), null, false, null, null, "Sam Sung OLED SS115", null, 9000000.0 },
                    { 5, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6853), null, false, null, null, "Điều hòa Panasonic siêu mát lạnh", null, 6000000.0 },
                    { 6, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6857), null, false, null, null, "Máy lạnh Tosiba buốt giá con tim", null, 5000000.0 },
                    { 7, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6916), null, false, null, null, "Tủ lạnh LG GG", null, 7000000.0 },
                    { 8, null, null, null, new DateTime(2024, 9, 20, 13, 38, 49, 150, DateTimeKind.Local).AddTicks(6918), null, false, null, null, "Máy giặt AQUA ảo quá", null, 8000000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
