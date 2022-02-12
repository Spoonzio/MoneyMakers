using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class baseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencySym = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyFullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencySym);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CAD", "Canadian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "EUR", "Euro" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "USD", "US Dollar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
