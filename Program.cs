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
            bool doItAgain = true;
            WeatherReport forecast = new();
            dynamic weather = null;

            do
            {
                string city = Display.SelectCity().Trim();

                if (city.ToUpper() != "X")
                {

                    weather = await forecast.GetForecast(city);

                    if (weather == null)
                    {
                        Console.WriteLine("No weather data was returned.\nCheck location and try again\nor X to quit.");
                    }
                    else
                    {
                        doItAgain = false;  
                    }
                } 
                else
                {
                    doItAgain = false;
                }
            } while (doItAgain == true);

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
                        Display.ShowForecast(weather);
                        doItAgain = true;
                        break;

                    case "3":
                        //Console.WriteLine("\n" + GetWeatherHistory());
                        doItAgain = true;
                        break;

                    case "4":
                        //Console.WriteLine("\n" + SelectCity());
                        doItAgain = true;
                        break;


                    case "X":
                    case "x":
                        doItAgain = false;
                        break;

                    default:
                        doItAgain = true;
                        break;
                }

                if (doItAgain == true)
                {
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                }

            }
            while (doItAgain == true);



            //Console.WriteLine("Please enter the name of a city or a postal code: ");
            //string city = Console.ReadLine();

            //WeatherReport forecast = new();
            //dynamic weather = await forecast.GetForecast(city.Trim());

            //if (weather == null)
            //{
            //    Console.WriteLine("No weather data was returned. Check location and try again.");
            //}
            //else
            //{
            //    Display.ShowForecast(weather);
            //}
        }



    

           
    }
}
