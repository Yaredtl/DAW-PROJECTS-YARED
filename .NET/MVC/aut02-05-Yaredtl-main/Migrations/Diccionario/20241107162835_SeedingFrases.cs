using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUT02_05.Migrations.Diccionario
{
    /// <inheritdoc />
    public partial class SeedingFrases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "Frase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Frase",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 42,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 43,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 45,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 46,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 47,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 48,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 49,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.UpdateData(
                table: "Frase",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "IdUser", "UserId" },
                values: new object[] { "0", null });

            migrationBuilder.CreateIndex(
                name: "IX_Frase_UserId",
                table: "Frase",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frase_IdentityUser_UserId",
                table: "Frase",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frase_IdentityUser_UserId",
                table: "Frase");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Frase_UserId",
                table: "Frase");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Frase");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Frase");
        }
    }
}
