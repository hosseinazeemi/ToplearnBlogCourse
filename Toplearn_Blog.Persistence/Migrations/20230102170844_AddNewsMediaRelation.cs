using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToplearnBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsMediaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Media_TableRowId",
                table: "Media",
                column: "TableRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_News_TableRowId",
                table: "Media",
                column: "TableRowId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_News_TableRowId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_TableRowId",
                table: "Media");
        }
    }
}
