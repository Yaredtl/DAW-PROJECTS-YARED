using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jardineria_Gabriel.Migrations
{
    /// <inheritdoc />
    public partial class SwappedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Review",
                newName: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Review",
                newName: "Id");
        }
    }
}
