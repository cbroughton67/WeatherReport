using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherReport
    {
        private string city;

        public string City { get => city; set => city = value; }

        public async Task<dynamic> GetForecast()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "?key=UTETUQF62KSYHT42GZJ248MJ2");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if error
                var body = await response.Content.ReadAsStringAsync();

                dynamic weather = JsonConvert.DeserializeObject(body);
                return weather;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<dynamic> GetWeatherHistory()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "/last15days?include=fcst%2Cobs%2Chistfcst%2Cstats%2Chours&key=UTETUQF62KSYHT42GZJ248MJ2&options=preview&contentType=json");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if error
                var body = await response.Content.ReadAsStringAsync();

                dynamic weather = JsonConvert.DeserializeObject(body);
                return weather;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
