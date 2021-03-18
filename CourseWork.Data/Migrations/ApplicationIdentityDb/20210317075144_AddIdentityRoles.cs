using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWork.Data.Migrations.ApplicationIdentityDb
{
    public partial class AddIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d35bf2a-d095-4b20-92e3-6601c8594a91", "41da3db7-94cc-4772-816f-912222371186", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0afdd7d-1d72-42d8-abd5-60d52012134b", "50d3a70a-6f77-4e29-a3d0-7e27137e9520", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d35bf2a-d095-4b20-92e3-6601c8594a91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0afdd7d-1d72-42d8-abd5-60d52012134b");
        }
    }
}
