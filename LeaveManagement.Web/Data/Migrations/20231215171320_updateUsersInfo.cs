using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class updateUsersInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "429f46f1-569b-4f3c-bc41-7b23a5ca38f8",
                columns: new[] { "NormalizedUserName" },
                values: new object[] { "USER@LOCALHOST.COM" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "NormalizedUserName" },
                values: new object[] { "ADMIN@LOCALHOST.COM" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
