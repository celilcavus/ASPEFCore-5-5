using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ProductDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "'Ürün Adi Girilmemiş'",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatingDate",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatingDate",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "'Ürün Adi Girilmemiş'");
        }
    }
}
