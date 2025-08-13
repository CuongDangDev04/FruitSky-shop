using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitSky.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_CartItemModel_CartItemId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Checkouts_CheckoutModelId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CartItemModel");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CartItemId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "Checkouts");

            migrationBuilder.RenameColumn(
                name: "CheckoutModelId",
                table: "OrderDetails",
                newName: "CheckoutId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_CheckoutModelId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_CheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Checkouts_CheckoutId",
                table: "OrderDetails",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Checkouts_CheckoutId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "CheckoutId",
                table: "OrderDetails",
                newName: "CheckoutModelId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_CheckoutId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_CheckoutModelId");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "Checkouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CartItemId",
                table: "Checkouts",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemModel_ProductId",
                table: "CartItemModel",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_CartItemModel_CartItemId",
                table: "Checkouts",
                column: "CartItemId",
                principalTable: "CartItemModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Checkouts_CheckoutModelId",
                table: "OrderDetails",
                column: "CheckoutModelId",
                principalTable: "Checkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
