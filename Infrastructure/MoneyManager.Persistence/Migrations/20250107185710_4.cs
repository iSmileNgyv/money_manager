using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryType",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    FileName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.UniqueConstraint("AK_Media_Path", x => x.Path);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Image",
                table: "Categories",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Media_Path",
                table: "Media",
                column: "Path");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_Image",
                table: "Categories",
                column: "Image",
                principalTable: "Media",
                principalColumn: "Path",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Media_Image",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Image",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryType",
                table: "Categories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
