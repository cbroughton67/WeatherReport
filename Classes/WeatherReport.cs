using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherReport
    { 
        public async Task<dynamic> GetForecast(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "?key=UTETUQF62KSYHT42GZJ248MJ2");
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/here?key=UTETUQF62KSYHT42GZJ248MJ2");

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
