using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "594716ba-5d2a-430d-ab3e-ac973a64bc4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "8fb9362c-9ab4-4f2f-b1b4-b56eb7ab2e02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "666fff3f-f58e-4e67-a529-5786edbbac84", "AQAAAAEAACcQAAAAEBnl4HxUy48pJC4CUBPJE8Hxh1KlFpuM4657ixqlqfcY2Y/e+YnEdrqhdvWvcI0HFg==", "acd314ab-375e-4f55-ba0a-b2c9e62bfc3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9396a7ec-2370-4a7e-b412-727e9b7db0e7", "AQAAAAEAACcQAAAAELbh8D1NKhQjk2n1US/ZdawAFft70JNELgdjk6ImbJnBLEcYcvFNRsDI/TMoJNBqOA==", "8e625fbc-dd1a-42a3-9ea8-4c8b36564dd2" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
