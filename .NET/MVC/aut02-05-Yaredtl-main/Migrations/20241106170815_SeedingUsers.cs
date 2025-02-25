using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUT02_05.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77b045e0-8d47-436b-ba30-09614fc93ef7", null, "Admin", "ADMIN" },
                    { "d06c957c-5ef4-4fff-bf1f-6402ab807088", null, "Premium", "PREMIUM" },
                    { "d4a493e1-e05f-442f-a264-f96533216202", null, "Basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ccf525e-4995-47d6-b701-831d224c0e0a", 0, "1c531d64-4ccf-4673-9151-bbb93c3f26b0", "admin@diccionario.com", true, false, null, "ADMIN@DICCIONARIO.COM", "ADMIN@DICCIONARIO.COM", "AQAAAAIAAYagAAAAEL57Dn0cuC8B5wIzeD3Y1Cas45T6azy3VDNn7joyHvIxlKW6SHETmYw9lsEzGYHqhQ==", null, false, "286522dd-4d21-41fe-951c-fc1141fd8b1a", false, "admin@diccionario.com" },
                    { "4f03b2cd-12a8-41f4-bb3f-2ec9cbce9d18", 0, "1097194e-f845-4771-a4ed-2368c0e7a5bf", "basic@diccionario.com", true, false, null, "BASIC@DICCIONARIO.COM", "BASIC@DICCIONARIO.COM", "AQAAAAIAAYagAAAAELH/y146Uo3WqH7OHUquLsql5hg4KE5oG9kdNTgrhefLSSNnqgnjlWGLYppeM9FZqA==", null, false, "71e9845a-4a5f-44c2-b8a0-123cae7879bd", false, "basic@diccionario.com" },
                    { "92e4aa8b-eaa0-4b32-b72e-b8c7dfcb80a1", 0, "832f2c7b-b3a3-4e0c-b7e8-1865114c1892", "premium@diccionario.com", true, false, null, "PREMIUM@DICCIONARIO.COM", "PREMIUM@DICCIONARIO.COM", "AQAAAAIAAYagAAAAEMm569QOBipMzX4Y5H6Kjha+LOU8Ao4sRWeoOt5VbiqjR+FebOIWEQyQxxL4oTPcDA==", null, false, "dd1fa780-d8f6-4765-8ce9-ee81c4c6ef91", false, "premium@diccionario.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "77b045e0-8d47-436b-ba30-09614fc93ef7", "3ccf525e-4995-47d6-b701-831d224c0e0a" },
                    { "d4a493e1-e05f-442f-a264-f96533216202", "4f03b2cd-12a8-41f4-bb3f-2ec9cbce9d18" },
                    { "d06c957c-5ef4-4fff-bf1f-6402ab807088", "92e4aa8b-eaa0-4b32-b72e-b8c7dfcb80a1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77b045e0-8d47-436b-ba30-09614fc93ef7", "3ccf525e-4995-47d6-b701-831d224c0e0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4a493e1-e05f-442f-a264-f96533216202", "4f03b2cd-12a8-41f4-bb3f-2ec9cbce9d18" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d06c957c-5ef4-4fff-bf1f-6402ab807088", "92e4aa8b-eaa0-4b32-b72e-b8c7dfcb80a1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b045e0-8d47-436b-ba30-09614fc93ef7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d06c957c-5ef4-4fff-bf1f-6402ab807088");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a493e1-e05f-442f-a264-f96533216202");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf525e-4995-47d6-b701-831d224c0e0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f03b2cd-12a8-41f4-bb3f-2ec9cbce9d18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92e4aa8b-eaa0-4b32-b72e-b8c7dfcb80a1");
        }
    }
}
