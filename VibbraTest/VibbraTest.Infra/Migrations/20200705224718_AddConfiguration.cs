using Microsoft.EntityFrameworkCore.Migrations;

namespace VibbraTest.Infra.Migrations
{
    public partial class AddConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxRevenueAmount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    SmsNotification = table.Column<bool>(nullable: false),
                    EmailNotification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "Id", "EmailNotification", "MaxRevenueAmount", "SmsNotification" },
                values: new object[] { 1, false, 10000m, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");
        }
    }
}
