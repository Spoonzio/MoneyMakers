using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MoneyMaker.Services;
public class ApiService
{
    public HttpClient client;
    private const string BASE_URL = "https://api.exchangerate.host";

    public ApiService(){
        client = new HttpClient();
    }

    public async Task<float> GetRate(String fromUnit, String toUnit)
    {
        // Build URL for API call
        string url = BASE_URL + "/latest?base=" + fromUnit + "&symbols=" + toUnit;
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Get response
        HttpResponseMessage response = await client.GetAsync(url);
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
    
    // public async Task<float[]> GetMonthRate(String fromUnit){
    //     // TODO https://api.exchangerate.host/timeseries?start_date=2020-01-01&end_date=2020-01-04&from=USD
    // }

}
