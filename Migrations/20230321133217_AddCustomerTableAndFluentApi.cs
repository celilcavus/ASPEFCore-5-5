using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTableAndFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "c",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "c",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.EnsureSchema(
                name: "c");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product",
                newSchema: "c");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "c",
                table: "Product",
                column: "Id");
        }
    }
}
