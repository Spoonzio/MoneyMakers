using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class PortfolioKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioEntry",
                table: "PortfolioEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioEntry",
                table: "PortfolioEntry",
                columns: new[] { "UserId", "EntryCurrencySym" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioEntry",
                table: "PortfolioEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioEntry",
                table: "PortfolioEntry",
                columns: new[] { "UserId", "EntryCurrencySym", "EntryValue" });
        }
    }
}
