using MoneyMaker.Models;
using MoneyMaker.Services;
using Newtonsoft.Json.Linq;

namespace MoneyMaker.Data;

public class SampleData
{
    public static List<Currency> GetCurrencies()
    {
        List<Currency> currencies = new List<Currency>();

        string jsonstr = File.ReadAllText(@"Data\Currency.json");
        JObject json = JObject.Parse(jsonstr);
        if (json.ContainsKey("currencies"))
        {
            string currenciesStr = json["currencies"].ToString();
            JObject currenciesJson = JObject.Parse(currenciesStr);
            foreach (var curr in currenciesJson)
            {
                JObject currencyJson = JObject.Parse(curr.Value.ToString());

                string currencySym = currencyJson["code"].ToString();
                string currencyFullName = currencyJson["description"].ToString();

                Currency currencyObj = new Currency()
                {
                    CurrencyFullName = currencyFullName,
                    CurrencySym = currencySym
                };

                if (currencySym != null && currencyFullName != null) currencies.Add(currencyObj);
            }
        }
        else
        {
            currencies = new List<Currency>() {
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
        }

        return currencies;
    }
}