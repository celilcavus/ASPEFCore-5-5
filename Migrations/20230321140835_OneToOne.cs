using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspEFCore.Migrations
{
    /// <inheritdoc />
    public partial class OneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saleHistories_products_ProductId",
                table: "saleHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saleHistories",
                table: "saleHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "saleHistories",
                newName: "SaleHistories");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_saleHistories_ProductId",
                table: "SaleHistories",
                newName: "IX_SaleHistories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleHistories",
                table: "SaleHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleHistories_Products_ProductId",
                table: "SaleHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleHistories_Products_ProductId",
                table: "SaleHistories");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleHistories",
                table: "SaleHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "SaleHistories",
                newName: "saleHistories");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_SaleHistories_ProductId",
                table: "saleHistories",
                newName: "IX_saleHistories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saleHistories",
                table: "saleHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_saleHistories_products_ProductId",
                table: "saleHistories",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
