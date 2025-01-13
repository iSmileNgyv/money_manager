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
                name: "FK_Categories_Media_Image",
                table: "Categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Media_Path",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Media_Path",
                table: "Medias",
                newName: "IX_Medias_Path");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Medias_Path",
                table: "Medias",
                column: "Path");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Medias_Image",
                table: "Categories",
                column: "Image",
                principalTable: "Medias",
                principalColumn: "Path",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Medias_Image",
                table: "Categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Medias_Path",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_Path",
                table: "Media",
                newName: "IX_Media_Path");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Media_Path",
                table: "Media",
                column: "Path");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Media_Image",
                table: "Categories",
                column: "Image",
                principalTable: "Media",
                principalColumn: "Path",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
