using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRequestCommentsInLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aee24cd-d60e-42ac-9544-7a1e04859756",
                column: "ConcurrencyStamp",
                value: "0200a8ef-f5fb-4948-92b9-aeb8471228a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cbe24dd-d50e-42ae-9314-7c1b04056746",
                column: "ConcurrencyStamp",
                value: "5e748ca6-e1e3-48ce-a12c-b0a30e136913");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f912b4b0-7298-4b76-a933-1c33ff0fae47", "AQAAAAEAACcQAAAAENbBT9yzx1xD3AA/fcWyBR9K+miCIi4wbmEH/cir3kksDPirz48PoWf9wK0bbVLe1Q==", "4ad351c5-60fe-44b2-9d11-6f2c4faa8ff4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdafcf88-1dd4-4f36-8961-7c8df2f2da5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c629d00-525d-4839-ba24-0ef02250df7f", "AQAAAAEAACcQAAAAEJIT5dsByT04ZjCRgnJt4ZGL4DBa2uQSVVOj+89VuNosEDv8wGGf5AGf/JTp6fbLiQ==", "2eb5c705-1d1c-4c84-a8ae-2c89a47058d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
