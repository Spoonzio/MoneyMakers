using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class PortfolioRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.CreateTable(
                name: "PortfolioEntry",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    EntryCurrencySym = table.Column<string>(type: "TEXT", nullable: false),
                    EntryValue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioEntry", x => new { x.UserId, x.EntryCurrencySym, x.EntryValue });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioEntry");

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    EntryCurrencySym = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => new { x.UserId, x.EntryCurrencySym, x.Value });
                });
        }
    }
}
