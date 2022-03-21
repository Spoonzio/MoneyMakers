using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class Portfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alert",
                table: "Alert");

            migrationBuilder.RenameTable(
                name: "Alert",
                newName: "Alerts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                columns: new[] { "UserId", "FromCurrency", "ToCurrency" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts");

            migrationBuilder.RenameTable(
                name: "Alerts",
                newName: "Alert");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alert",
                table: "Alert",
                columns: new[] { "UserId", "FromCurrency", "ToCurrency" });
        }
    }
}
