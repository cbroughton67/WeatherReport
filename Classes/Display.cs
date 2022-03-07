using System;

namespace WeatherApp
{
    public class Display
    {
        public static void ShowForecast(dynamic forecastData)
        {
            bool alternate = false;
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*****                    WEATHER MONKEY                    *****");
            Console.WriteLine("****************************************************************");
            Console.WriteLine();
            Console.WriteLine("Forecast for: " + forecastData.resolvedAddress);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Date\t\tHigh(F)\tLow(F)\tPrecip(%)\tConditions");


            foreach (var day in forecastData.days)
            {
            
                if(alternate == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    alternate = false;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Blue;
                    alternate = true;
                }

                Console.WriteLine(day.datetime + "\t" + day.tempmax + "\t" + day.tempmin + "\t" + day.precipprob + "\t\t" + day.conditions);

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static string CreateMenu(string Location)
        {
            string valueEntered;

            do   //do until valid menu selection entered
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("****************************************************************");
                Console.WriteLine("*****                    WEATHER MONKEY                    *****");
                Console.WriteLine("****************************************************************");
                Console.WriteLine("\tCurrent Location: " + Location);
                Console.WriteLine("****************************************************************");
                Console.WriteLine();
                Console.WriteLine("\tChoose an option:");
                Console.WriteLine("\t1) Display Current Conditions");
                Console.WriteLine("\t2) Display 14 Day Forecast");
                Console.WriteLine("\t3) Display Previous 14 Days Weather");
                Console.WriteLine("\t4) Change City");
                Console.WriteLine("\t5) Email Forecast");
                Console.WriteLine("\tX) Exit Program");
                Console.Write("\r\n\tSelect an option: ");

                valueEntered = Convert.ToString(Console.ReadKey().KeyChar);
            }
            while (valueEntered != "1" &&
                   valueEntered != "2" &&
                   valueEntered != "3" &&
                   valueEntered != "4" &&
                   valueEntered != "5" &&
                   valueEntered != "X" &&
                   valueEntered != "x");

            return valueEntered;
        }

        public static string PromptForCity()
        {
            string city;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*****                    WEATHER MONKEY                    *****");
            Console.WriteLine("****************************************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter a city name or postal code (or X to quit):");
            city = Console.ReadLine();

            return city;
        }


        public static void ShowCurrentConditions(dynamic forecastData)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*****                    WEATHER MONKEY                    *****");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("\tCurrent Conditions for: " + forecastData.resolvedAddress);
            Console.WriteLine("****************************************************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\tCurrent Temp: \t\t" + forecastData.currentConditions.temp + "(F)");
            Console.WriteLine("\tPrecipitation: \t\t" + forecastData.currentConditions.precip + "in");
            Console.WriteLine("\tWind Speed: \t\t" + forecastData.currentConditions.windspeed + "mph");
            Console.WriteLine("\tWind Direction: \t" + forecastData.currentConditions.winddir + " degrees");
            Console.WriteLine("\tVisibility: \t\t" + forecastData.currentConditions.visibility + " miles");
            Console.WriteLine("\tPressure: \t\t" + forecastData.currentConditions.pressure + " millibars");
            Console.WriteLine("\tCurrent Conditions: \t" + forecastData.currentConditions.conditions);

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\n\tPress any key to continue.");
            Console.ReadKey();
        }
    }


}
