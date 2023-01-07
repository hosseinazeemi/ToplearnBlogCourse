using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToplearnBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNewsMediaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_News_TableRowId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_TableRowId",
                table: "Media");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
