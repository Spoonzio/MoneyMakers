using MoneyMaker.Models;
namespace MoneyMaker.Data;

public class SampleData
{
    public static List<Currency> GetCurrencies()
    {
        List<Currency> teams = new List<Currency>() {
            new Currency() {
                CurrencyFullName="US Dollar",
                CurrencySym="USD"
            },
            new Currency() {
                CurrencyFullName="Euro",
                CurrencySym="EUR"
            },
            new Currency() {
                CurrencyFullName="Canadian Dollar",
                CurrencySym="CAD"
            }
        };

        return teams;
    }
}