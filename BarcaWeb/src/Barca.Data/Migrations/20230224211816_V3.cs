using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barca.Data.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_M_ORDER_Client_UserId",
                table: "M_ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_M_ORDER_Payment_PaymentId",
                table: "M_ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_M_PRODUCT_M_CATEGORY_CategoryID",
                table: "M_PRODUCT");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_M_ORDER_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_M_PRODUCT_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_M_ORDER_OrderID",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_PRODUCT",
                table: "M_PRODUCT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_ORDER",
                table: "M_ORDER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_CATEGORY",
                table: "M_CATEGORY");

            migrationBuilder.RenameTable(
                name: "M_PRODUCT",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "M_ORDER",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "M_CATEGORY",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_M_PRODUCT_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_M_ORDER_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_M_ORDER_PaymentId",
                table: "Order",
                newName: "IX_Order_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Order_OrderID",
                table: "Sale",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_PaymentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Order_OrderID",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "M_PRODUCT");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "M_ORDER");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "M_CATEGORY");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "M_PRODUCT",
                newName: "IX_M_PRODUCT_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "M_ORDER",
                newName: "IX_M_ORDER_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PaymentId",
                table: "M_ORDER",
                newName: "IX_M_ORDER_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_PRODUCT",
                table: "M_PRODUCT",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_ORDER",
                table: "M_ORDER",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_CATEGORY",
                table: "M_CATEGORY",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_M_ORDER_Client_UserId",
                table: "M_ORDER",
                column: "UserId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_ORDER_Payment_PaymentId",
                table: "M_ORDER",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_PRODUCT_M_CATEGORY_CategoryID",
                table: "M_PRODUCT",
                column: "CategoryID",
                principalTable: "M_CATEGORY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_M_ORDER_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "M_ORDER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_M_PRODUCT_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "M_PRODUCT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_M_ORDER_OrderID",
                table: "Sale",
                column: "OrderID",
                principalTable: "M_ORDER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
