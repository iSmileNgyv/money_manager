using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Objects",
                table: "Objects");

            migrationBuilder.RenameTable(
                name: "Objects",
                newName: "Stocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Objects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objects",
                table: "Objects",
                column: "Id");
        }
    }
}
