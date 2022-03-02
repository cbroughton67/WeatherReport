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
            Console.WriteLine("Forecast for: " + forecastData.resolvedAddress);
            Console.WriteLine("Date\t\tHigh(F)\tLow(F)\tPrecip(%)\tConditions");

            foreach (var day in forecastData.days)
            {
                Console.WriteLine(day.datetime + "\t" + day.tempmax + "\t" + day.tempmin + "\t" + day.precipprob + "\t\t" + day.conditions);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static string CreateMenu()
        {
            string valueEntered;

            do   //do until valid menu selection entered
            {
                Console.Clear();
                Console.WriteLine("****************************************************************");
                Console.WriteLine("*****                    WEATHER MONKEY                    *****");
                Console.WriteLine("****************************************************************");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Display Current Conditions");
                Console.WriteLine("2) Display 14 Day Forecast");
                Console.WriteLine("3) Display Previous 14 Days Weather");
                Console.WriteLine("4) Change City");
                Console.WriteLine("X) Exit Program");
                Console.Write("\r\nSelect an option: ");

                valueEntered = Convert.ToString(Console.ReadKey().KeyChar);
            }
            while (valueEntered != "1" &&
                   valueEntered != "2" &&
                   valueEntered != "3" &&
                   valueEntered != "4" &&
                   valueEntered != "X" &&
                   valueEntered != "x");

            return valueEntered;
        }

        //public static void PeformSelectedMenuOption(string selection)
        //{
        //    bool doItAgain = true;

        //    do
        //    {
        //        switch (selection)
        //        {
        //            case "1":
        //                //Console.WriteLine("\n" + CurrentConditions());
        //                doItAgain = true;
        //                break;

        //            case "2":
        //                Console.WriteLine("\n" + ShowForecast());
        //                doItAgain = true;
        //                break;

        //            case "3":
        //                Console.WriteLine("\n" + GetWeatherHistory());
        //                doItAgain = true;
        //                break;

        //            case "4":
        //                Console.WriteLine("\n" + SelectCity());
        //                doItAgain = true;
        //                break;


        //            case "X":
        //            case "x":
        //                doItAgain = false;
        //                break;

        //            default:
        //                doItAgain = true;
        //                break;
        //        }

        //        if (doItAgain == true)
        //        {
        //            Console.WriteLine("Press a key to continue...");
        //            Console.ReadKey();
        //        }

        //    }
        //    while (doItAgain == true);
        //}

        public static string SelectCity()
        {
            string city;
            Console.WriteLine("\nPlease enter a city name or postal code:");
            city = Console.ReadLine();

            return city;
        }

    }


}
