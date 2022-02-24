using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Display
    {
        public static void ShowForecast(dynamic forecastData)
        {
            Console.Clear();
            Console.WriteLine("Forecast for : " + forecastData.resolvedAddress);
            Console.WriteLine("Date\t\tHigh\tLow\tPrecip\tConditions");

            foreach (var day in forecastData.days)
            {
                Console.WriteLine(day.datetime + "\t" + day.tempmax + "\t" + day.tempmin + "\t" + day.precipprob + "\t" + day.conditions);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
