using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionProducts_Products_ProductId",
                table: "TransactionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionProducts_Transactions_TransactionId",
                table: "TransactionProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionProducts_Products_ProductId",
                table: "TransactionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionProducts_Transactions_TransactionId",
                table: "TransactionProducts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionProducts_Products_ProductId",
                table: "TransactionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionProducts_Transactions_TransactionId",
                table: "TransactionProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionProducts_Products_ProductId",
                table: "TransactionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionProducts_Transactions_TransactionId",
                table: "TransactionProducts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
