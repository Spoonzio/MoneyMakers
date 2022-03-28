using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class PortfolioCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "EntryValue",
                table: "PortfolioEntry",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EntryValue",
                table: "PortfolioEntry",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }
    }
}
