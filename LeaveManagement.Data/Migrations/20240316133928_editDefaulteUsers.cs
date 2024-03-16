using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class editDefaulteUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "e77d1477-0295-4d34-a680-f33f652cd867");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "5e3eeb67-fdca-44f1-a801-b0418f9a692a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ea32920-9a8a-42cb-8188-11f999bfd33a", "AQAAAAEAACcQAAAAEGz79fz0NW3DXP73l/6XgSgULXmbZNipthN7+uDACsWc8w95MGk+TdVnQ6OLaqFIHg==", "cca96d5c-11aa-4fbf-aac9-d202c867b38e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "429f46f1-569b-4f3c-bc41-7b23a5ca38f2", 0, "e0615385-5854-4fa7-80c5-cb3adc6a9a5d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEH4cBErsCwltbJerKxAo/tfo22Ty1OsfgnB8p0sNpvF4ot4HtQvxegY1QIpvPvecAA==", null, false, "7580e45a-8221-45d3-93c4-d8e2e602618a", null, false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "429f46f1-569b-4f3c-bc41-7b23a5ca38f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "429f46f1-569b-4f3c-bc41-7b23a5ca38f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "7ae27cd9-2180-4c3f-9468-dc019845e11c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "5125a7bf-9a3e-416a-be98-3079f045e680");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cbe24dd-d50e-42ae-9314-7c1b04056746", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9478d460-eb93-4bd3-baac-49dba5542950", "AQAAAAEAACcQAAAAELfW8rv8MavHJzgUEBsT6XWsf2keC53hEzC1nUKISpJ7sb4TURKsIZsq2mdDZTDs7w==", "65f66c50-170b-493f-a756-14e0c47c7345" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a", 0, "2772dc87-98ea-4ff2-8f2b-a1be3ae1ac7a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEK8ioz7ZarIQLMCHuoWq/pRy6Jrfi4tgF4qQEA2DO0kjtQ7X7ZO7uxPmtxh1y2TkHw==", null, false, "663ea3ed-a779-4ead-99b4-2c9be51b581d", null, false, "admin@localhost.com" });
        }
    }
}
