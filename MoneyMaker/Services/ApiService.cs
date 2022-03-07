using System.Net.Http.Headers;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoneyMaker.Services;
public class ApiService
{

    private readonly IHttpClientFactory _httpClientFactory;
    private const string BASE_URL = "https://api.exchangerate.host";
    private const int DAYS_IN_A_MONTH = 30;
    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<float> GetRate(String fromUnit, String toUnit)
    {
        // Build URL for API call
        string url = BASE_URL + "/latest?base=" + fromUnit + "&symbols=" + toUnit;
        var client = _httpClientFactory.CreateClient();

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url){};

        // Get response
        HttpResponseMessage response = await client.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            // Response OK
            string jsondata = await response.Content.ReadAsStringAsync();
            JsonReader reader = new JsonTextReader(new StringReader(jsondata));
            float rate = 0;

            // Find Rate value
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
                {

                    string jsonText = reader.Value!.ToString()!;
                    rate = float.Parse(jsonText!);
                }
            }

            return rate;
        }
        else
        {
            return -1;
        } 
    }
    
    public async Task<Dictionary<string, float>> GetMonthRate(string fromUnit, string toUnit){
        // TODO https://api.exchangerate.host/timeseries?start_date=2020-01-01&end_date=2020-01-04&from=USD

        // Build URL for API call
        DateTime today = DateTime.Today;
        DateTime oneMonthAgo = today.AddMonths(-1);

        // Normalise date
        string startDate = DateNormalizer(oneMonthAgo);
        string endDate = DateNormalizer(today);


        string url = BASE_URL + "/timeseries?start_date=" + startDate + "&end_date=" + endDate + "&base=" + fromUnit;
        var client = _httpClientFactory.CreateClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url) { };


        // Get response
        Dictionary<string, float> monthValue = new Dictionary<string, float>();
        HttpResponseMessage response = await client.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode){
            // Response OK
            string jsonstr = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(jsonstr);
            if (json.ContainsKey("rates"))
            {
                string rateStr = json["rates"].ToString();
                JObject rateJson = JObject.Parse(rateStr);
                foreach (var dayRate in rateJson)
                {
                    JObject dayRateJson = JObject.Parse(dayRate.Value.ToString());
                    string dayCurrencyRate = dayRateJson[toUnit.ToString()].ToString();
                    if(dayCurrencyRate!=null) monthValue.Add(dayRate.Key, float.Parse(dayCurrencyRate));
                }
            }
        }

        return monthValue;
    }


    private string DateNormalizer(DateTime date)
    {
        // Normalise date
        string year, month, day;
        year = date.Year.ToString();
        month = date.Month.ToString();
        month = month.Length == 1 ? "0" + month : month;

        day = date.Day.ToString();
        day = day.Length == 1 ? "0" + day : day;

        return year + "-" + month + "-" + day;
    }
}
