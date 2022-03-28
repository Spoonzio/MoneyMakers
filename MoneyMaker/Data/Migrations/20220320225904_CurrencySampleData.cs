using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMaker.Data.Migrations
{
    public partial class CurrencySampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "USD",
                column: "CurrencyFullName",
                value: "United States Dollar");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AED", "United Arab Emirates Dirham" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AFN", "Afghan Afghani" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ALL", "Albanian Lek" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AMD", "Armenian Dram" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ANG", "Netherlands Antillean Guilder" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AOA", "Angolan Kwanza" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ARS", "Argentine Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AUD", "Australian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AWG", "Aruban Florin" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "AZN", "Azerbaijani Manat" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BAM", "Bosnia-Herzegovina Convertible Mark" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BBD", "Barbadian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BDT", "Bangladeshi Taka" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BGN", "Bulgarian Lev" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BHD", "Bahraini Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BIF", "Burundian Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BMD", "Bermudan Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BND", "Brunei Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BOB", "Bolivian Boliviano" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BRL", "Brazilian Real" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BSD", "Bahamian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BTC", "Bitcoin" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BTN", "Bhutanese Ngultrum" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BWP", "Botswanan Pula" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BYN", "Belarusian Ruble" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "BZD", "Belize Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CDF", "Congolese Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CHF", "Swiss Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CLF", "Chilean Unit of Account (UF)" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CLP", "Chilean Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CNH", "Chinese Yuan (Offshore)" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CNY", "Chinese Yuan" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "COP", "Colombian Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CRC", "Costa Rican Col�n" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CUC", "Cuban Convertible Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CUP", "Cuban Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CVE", "Cape Verdean Escudo" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "CZK", "Czech Republic Koruna" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "DJF", "Djiboutian Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "DKK", "Danish Krone" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "DOP", "Dominican Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "DZD", "Algerian Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "EGP", "Egyptian Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ERN", "Eritrean Nakfa" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ETB", "Ethiopian Birr" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "FJD", "Fijian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "FKP", "Falkland Islands Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GBP", "British Pound Sterling" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GEL", "Georgian Lari" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GGP", "Guernsey Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GHS", "Ghanaian Cedi" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GIP", "Gibraltar Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GMD", "Gambian Dalasi" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GNF", "Guinean Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GTQ", "Guatemalan Quetzal" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "GYD", "Guyanaese Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "HKD", "Hong Kong Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "HNL", "Honduran Lempira" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "HRK", "Croatian Kuna" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "HTG", "Haitian Gourde" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "HUF", "Hungarian Forint" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "IDR", "Indonesian Rupiah" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ILS", "Israeli New Sheqel" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "IMP", "Manx pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "INR", "Indian Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "IQD", "Iraqi Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "IRR", "Iranian Rial" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ISK", "Icelandic Kr�na" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "JEP", "Jersey Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "JMD", "Jamaican Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "JOD", "Jordanian Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "JPY", "Japanese Yen" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KES", "Kenyan Shilling" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KGS", "Kyrgystani Som" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KHR", "Cambodian Riel" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KMF", "Comorian Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KPW", "North Korean Won" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KRW", "South Korean Won" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KWD", "Kuwaiti Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KYD", "Cayman Islands Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "KZT", "Kazakhstani Tenge" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LAK", "Laotian Kip" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LBP", "Lebanese Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LKR", "Sri Lankan Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LRD", "Liberian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LSL", "Lesotho Loti" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "LYD", "Libyan Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MAD", "Moroccan Dirham" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MDL", "Moldovan Leu" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MGA", "Malagasy Ariary" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MKD", "Macedonian Denar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MMK", "Myanma Kyat" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MNT", "Mongolian Tugrik" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MOP", "Macanese Pataca" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MRO", "Mauritanian Ouguiya (pre-2018)" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MRU", "Mauritanian Ouguiya" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MUR", "Mauritian Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MVR", "Maldivian Rufiyaa" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MWK", "Malawian Kwacha" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MXN", "Mexican Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MYR", "Malaysian Ringgit" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "MZN", "Mozambican Metical" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NAD", "Namibian Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NGN", "Nigerian Naira" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NIO", "Nicaraguan C�rdoba" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NOK", "Norwegian Krone" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NPR", "Nepalese Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "NZD", "New Zealand Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "OMR", "Omani Rial" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PAB", "Panamanian Balboa" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PEN", "Peruvian Nuevo Sol" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PGK", "Papua New Guinean Kina" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PHP", "Philippine Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PKR", "Pakistani Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PLN", "Polish Zloty" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "PYG", "Paraguayan Guarani" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "QAR", "Qatari Rial" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "RON", "Romanian Leu" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "RSD", "Serbian Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "RUB", "Russian Ruble" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "RWF", "Rwandan Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SAR", "Saudi Riyal" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SBD", "Solomon Islands Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SCR", "Seychellois Rupee" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SDG", "Sudanese Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SEK", "Swedish Krona" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SGD", "Singapore Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SHP", "Saint Helena Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SLL", "Sierra Leonean Leone" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SOS", "Somali Shilling" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SRD", "Surinamese Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SSP", "South Sudanese Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "STD", "S�o Tom� and Pr�ncipe Dobra (pre-2018)" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "STN", "S�o Tom� and Pr�ncipe Dobra" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SVC", "Salvadoran Col�n" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SYP", "Syrian Pound" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "SZL", "Swazi Lilangeni" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "THB", "Thai Baht" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TJS", "Tajikistani Somoni" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TMT", "Turkmenistani Manat" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TND", "Tunisian Dinar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TOP", "Tongan Pa'anga" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TRY", "Turkish Lira" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TTD", "Trinidad and Tobago Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TWD", "New Taiwan Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "TZS", "Tanzanian Shilling" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "UAH", "Ukrainian Hryvnia" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "UGX", "Ugandan Shilling" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "UYU", "Uruguayan Peso" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "UZS", "Uzbekistan Som" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "VEF", "Venezuelan Bol�var Fuerte (Old)" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "VES", "Venezuelan Bol�var Soberano" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "VND", "Vietnamese Dong" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "VUV", "Vanuatu Vatu" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "WST", "Samoan Tala" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XAF", "CFA Franc BEAC" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XAG", "Silver Ounce" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XAU", "Gold Ounce" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XCD", "East Caribbean Dollar" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XDR", "Special Drawing Rights" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XOF", "CFA Franc BCEAO" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XPD", "Palladium Ounce" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XPF", "CFP Franc" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "XPT", "Platinum Ounce" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "YER", "Yemeni Rial" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ZAR", "South African Rand" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ZMW", "Zambian Kwacha" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencySym", "CurrencyFullName" },
                values: new object[] { "ZWL", "Zimbabwean Dollar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alert",
                table: "Alert");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AED");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AFN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ALL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AMD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ANG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AOA");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ARS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AUD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AWG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "AZN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BAM");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BBD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BDT");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BGN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BHD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BIF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BMD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BND");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BOB");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BRL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BSD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BTC");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BTN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BWP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BYN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "BZD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CDF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CHF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CLF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CLP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CNH");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CNY");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "COP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CRC");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CUC");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CUP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CVE");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "CZK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "DJF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "DKK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "DOP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "DZD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "EGP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ERN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ETB");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "FJD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "FKP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GBP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GEL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GGP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GHS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GIP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GMD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GNF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GTQ");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "GYD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "HKD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "HNL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "HRK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "HTG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "HUF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "IDR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ILS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "IMP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "INR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "IQD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "IRR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ISK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "JEP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "JMD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "JOD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "JPY");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KES");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KGS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KHR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KMF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KPW");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KRW");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KWD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KYD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "KZT");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LAK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LBP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LKR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LRD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LSL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "LYD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MAD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MDL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MGA");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MKD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MMK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MNT");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MOP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MRO");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MRU");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MUR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MVR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MWK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MXN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MYR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "MZN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NAD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NGN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NIO");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NOK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NPR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "NZD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "OMR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PAB");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PEN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PGK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PHP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PKR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PLN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "PYG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "QAR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "RON");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "RSD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "RUB");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "RWF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SAR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SBD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SCR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SDG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SEK");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SGD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SHP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SLL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SOS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SRD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SSP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "STD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "STN");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SVC");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SYP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "SZL");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "THB");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TJS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TMT");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TND");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TOP");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TRY");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TTD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TWD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "TZS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "UAH");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "UGX");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "UYU");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "UZS");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "VEF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "VES");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "VND");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "VUV");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "WST");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XAF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XAG");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XAU");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XCD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XDR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XOF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XPD");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XPF");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "XPT");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "YER");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ZAR");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ZMW");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "ZWL");

            migrationBuilder.RenameTable(
                name: "Alert",
                newName: "Alerts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                columns: new[] { "UserId", "FromCurrency", "ToCurrency" });

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "CurrencySym",
                keyValue: "USD",
                column: "CurrencyFullName",
                value: "US Dollar");
        }
    }
}
