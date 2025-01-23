using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_Categories_CategoryId",
                table: "Cashbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_PaymentMethods_PaymentMethodId",
                table: "Cashbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_Stocks_StockId",
                table: "Cashbacks");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Image",
                table: "Products",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Image",
                table: "PaymentMethods",
                column: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_Categories_CategoryId",
                table: "Cashbacks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_PaymentMethods_PaymentMethodId",
                table: "Cashbacks",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_Stocks_StockId",
                table: "Cashbacks",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Medias_Image",
                table: "PaymentMethods",
                column: "Image",
                principalTable: "Medias",
                principalColumn: "Path",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Medias_Image",
                table: "Products",
                column: "Image",
                principalTable: "Medias",
                principalColumn: "Path",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_Categories_CategoryId",
                table: "Cashbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_PaymentMethods_PaymentMethodId",
                table: "Cashbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cashbacks_Stocks_StockId",
                table: "Cashbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Medias_Image",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Medias_Image",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Image",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_Image",
                table: "PaymentMethods");

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_Categories_CategoryId",
                table: "Cashbacks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_PaymentMethods_PaymentMethodId",
                table: "Cashbacks",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cashbacks_Stocks_StockId",
                table: "Cashbacks",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
