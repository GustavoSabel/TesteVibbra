using Microsoft.EntityFrameworkCore.Migrations;

namespace VibbraTest.Infra.Migrations
{
    public partial class ChangePasswordUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "mHY82PbUYG3dhTeBCk38Oda5b4KlwVuClGJlA0329/4rWIw+");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Admin");
        }
    }
}
