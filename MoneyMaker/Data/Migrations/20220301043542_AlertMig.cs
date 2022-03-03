using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class AlertMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromCurrency = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToCurrency = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isBelow = table.Column<bool>(type: "bit", nullable: false),
                    ConditionValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => new { x.UserId, x.FromCurrency, x.ToCurrency });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}
