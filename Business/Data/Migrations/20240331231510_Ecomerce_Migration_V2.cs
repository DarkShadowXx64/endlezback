using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ecomerce_Migration_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Order_Product_ProductId",
            //    table: "Order");

            //migrationBuilder.DropIndex(
            //    name: "IX_Order_ProductId",
            //    table: "Order");

            //migrationBuilder.DropColumn(
            //    name: "ProductId",
            //    table: "Order");

            //migrationBuilder.CreateTable(
            //    name: "OrderProduct",
            //    columns: table => new
            //    {
            //        OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderProduct", x => new { x.OrderId, x.ProductId, x.CompanyId });
            //        table.ForeignKey(
            //            name: "FK_OrderProduct_Company_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Company",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderProduct_Order_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Order",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderProduct_Product_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Product",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_CompanyId",
                table: "OrderProduct",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
