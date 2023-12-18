using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class addDefaulteUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4aee24cd-d60e-42ac-9544-7a1e04859756", "b160e86d-e99c-40f9-bdeb-f2c1e4dd0d19", "User", "USER" },
                    { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "91071fd8-5b3c-4b1a-a717-e6e3b2705af5", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "408aa945-3d84-4421-8342-7269ec64d949", 0, "9dcf7ec2-d092-4765-b89d-f0100a26b86c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEIX4WXr7HeQ7SRQVqkFw0LhqehiZ+4zQqP0DsnTuI+9MCreBWZMN/nv7byffNnU6Rw==", null, false, "8d3c9303-a148-4d03-9a55-112c950a05c2", null, false, "admin@localhost.com" },
                    { "429f46f1-569b-4f3c-bc41-7b23a5ca38f8", 0, "77aba86e-685d-4c84-89ce-710679fc2211", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEHpBks3EpYwan8Sp9DwsaALdW2QhczHrVrAyWGc8mXfdyfCiBvV3wOpHfOlQMSlsZA==", null, false, "5962ac94-8767-4b83-8ffc-e46cb6bd8c31", null, false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4aee24cd-d60e-42ac-9544-7a1e04859756", "429f46f1-569b-4f3c-bc41-7b23a5ca38f8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4aee24cd-d60e-42ac-9544-7a1e04859756", "429f46f1-569b-4f3c-bc41-7b23a5ca38f8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8");
        }
    }
}
