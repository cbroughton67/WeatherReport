using System;
using System.Threading.Tasks;
//using System.Net.Http;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;

namespace WeatherApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WeatherReport forecast = new();
            dynamic weather = await forecast.GetWeather();

            if (weather == null)
            {
                Console.WriteLine("No weather data was returned. Check location and try again.");
            }
            else
            {
                Display.ShowForecast(weather);
            }
        }

           
    }
}
