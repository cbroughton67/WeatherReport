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
            string selection;
            bool doItAgain;
            WeatherReport forecast = new();
            dynamic weather;
            Task<string> pickCity;
            string city;

            pickCity = SelectCity();
            city = pickCity.Result;


            do
            {

                selection = Display.CreateMenu();

                switch (selection)
                {
                    case "1":
                        //Console.WriteLine("\n" + CurrentConditions());
                        doItAgain = true;
                        break;

                    case "2":
                        Console.WriteLine("\n");
                        weather = await forecast.GetForecast(city);
                        Display.ShowForecast(weather);
                        doItAgain = true;
                        break;

                    case "3":
                        weather = await forecast.GetWeatherHistory(city);
                        Display.ShowForecast(weather);
                        doItAgain = true;
                        break;

                    case "4":
                        pickCity = SelectCity();
                        city = pickCity.Result;

                        if (city == String.Empty)
                        {
                            doItAgain = false;
                        }
                        else
                        {  
                            doItAgain = true;
                        }
                        break;


                    case "X":
                    case "x":
                        doItAgain = false;
                        break;

                    default:
                        doItAgain = true;
                        break;
                }

                //if (doItAgain == true)
                //{
                //    Console.WriteLine("Press a key to continue...");
                //    Console.ReadKey();
                //}

            }
            while (doItAgain == true);

        }


        private static async Task<string> SelectCity()
        {
            bool doItAgain = true;
            string city;
            WeatherReport forecast = new();
            dynamic weather;

            do
            {
                city = Display.SelectCity().Trim();

                if (city.ToUpper() != "X")
                {

                    weather = await forecast.GetForecast(city);

                    if (weather == null)
                    {
                        Console.Clear();
                        Console.WriteLine("No weather data was returned.\nCheck location and try again\nor X to quit.");
                        doItAgain = true;
                    }
                    else
                    {
                        doItAgain = false;
                    }
                }
                else
                {
                    doItAgain = false;
                    city = String.Empty;
                }
            } while (doItAgain == true);

            return city;
        }
    

           
    }
}
