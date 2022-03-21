using System;
using System.Threading.Tasks;
using WeatherApp.Classes;
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
            string userEmail;
            WeatherReport forecast = new();
            dynamic weather;
            Task<string> pickCity;

            Console.ForegroundColor = ConsoleColor.Blue;

            // Set current city to last used location from previous session (if exists)
            forecast.City = FileIO.ReadLocaleFromFile("Weather.json");
            
            // if no previously saved city is available, prompt user for one
            if (forecast.City == String.Empty)
            {
                pickCity = SelectCity();
                forecast.City = pickCity.Result;
            }
            
            // If no default city found and user exited prompt without providing a valid city, set the app to exit
            if(forecast.City == string.Empty)
            {
                doItAgain = false;
            }
            
            // MAIN LOOP
            while (doItAgain == true)
            {
                // display menu
                selection = Display.CreateMenu(forecast.City);
                
                // process user's menu selection
                switch (selection)
                {
                    case "1":
                        weather = await forecast.GetForecast();
                        Display.ShowCurrentConditions(weather);
                        doItAgain = true;
                        break;

                    case "2":
                        weather = await forecast.GetForecast();
                        Display.ShowForecast(weather);
                        doItAgain = true;
                        break;

                    case "3":
                        weather = await forecast.GetWeatherHistory();
                        Display.ShowForecast(weather);
                        doItAgain = true;
                        break;

                    case "4":
                        pickCity = SelectCity();
                        forecast.City = pickCity.Result;

                        if (forecast.City == String.Empty)
                        {
                            doItAgain = false;
                        }
                        else
                        {  
                            doItAgain = true;
                        }
                        break;

                    case "5":
                        weather = await forecast.GetForecast();
                        userEmail = WeatherMail.GetUserEmail();
                        if(userEmail.ToUpper() != "X") //if the user didn't bail out before providing email...
                        {
                            WeatherMail.SendEmail(userEmail, weather); // send the email
                        }
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

            }

        }


        private static async Task<string> SelectCity()
        {
            // Prompt user for city / location to be used
            bool doItAgain = true;
            WeatherReport forecast = new();
            dynamic weather;
            Console.Clear();

            do
            {
                forecast.City = Display.PromptForCity().Trim();

                if (forecast.City.ToUpper() != "X")
                {

                    weather = await forecast.GetForecast();

                    if (weather is null) // City provided didn't resolve with Web API
                    {
                        Console.Clear();
                        Console.WriteLine("No weather data was returned. Check location and try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        doItAgain = true;
                    } 
                    else
                    {
                        forecast.City = weather["resolvedAddress"].ToString(); 
                        doItAgain = false;

                        FileIO.Locale locale = new();
                        locale.City = forecast.City;

                        // Save city to JSON file for next session
                        FileIO.WriteCityToJSON(locale, "Weather.json");

                    }
                }
                else
                {
                    doItAgain = false;
                    forecast.City = String.Empty;
                }
            } while (doItAgain == true);

            return forecast.City;
        }
    
    }
}
