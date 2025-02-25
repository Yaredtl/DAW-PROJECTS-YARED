using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discografia.Migrations
{
    /// <inheritdoc />
    public partial class SeedingReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ArtistId", "Description", "Points", "Title" },
                values: new object[,]
                {
                    { 1, 212, "Re loco el concierto", 4, "Ta bueno" },
                    { 2, 155, "Decepcionante", 1, "Conierto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
