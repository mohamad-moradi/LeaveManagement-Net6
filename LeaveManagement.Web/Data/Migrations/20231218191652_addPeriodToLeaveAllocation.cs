using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class addPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "bce1760c-8fc4-4000-aa58-cd5f5cd467a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "7bd2485f-6f5c-43ff-8439-0d9aea6ed02a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06d0fb81-b344-4cff-8b14-e5be74486aff", "AQAAAAEAACcQAAAAEINwqjQFL663RHkIKNkkjZLwdrAH+J2hJ4U8x6nB6GY/PmjG8qTj6dB0w5z36KdYPQ==", "7084f164-3461-4e27-a711-90c4bd4e7281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0493e5c-63f6-40cc-b839-c8761debe2cf", "AQAAAAEAACcQAAAAEKZL+jDq+yOJffoW6KG79VVyZQVgL0v4cH207c4PNN2+GdlLlbayZPZYLGVnDUfhAw==", "9be827f8-b2d4-47fb-aa7d-0e1fbecbe176" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "b79da105-2f4a-4609-9160-1c105a6cd529");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "e856a3a1-2bf4-434b-8b84-19c535171fe8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef87d7b1-d437-4e54-aa46-216cd38486aa", "AQAAAAEAACcQAAAAEAk/KKpxgBgEWAKOP4fDkZHdbX3KZEdSSdL/j2vZZfeWKj9YdWxnfkVSjwRV0VsiEg==", "fee0581f-4f79-4251-bc51-6634ef7ed346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9663708e-7f06-4276-80d6-408ac3126a87", "AQAAAAEAACcQAAAAELcj4LBZfrQm7ePzTODhbF/3V8nsaUidU2nJ8myzWojFm7VO+/NYTc9Bo1aTaNg81w==", "a075e9ec-cb2d-4111-99b8-4d668aa0e6f7" });
        }
    }
}
