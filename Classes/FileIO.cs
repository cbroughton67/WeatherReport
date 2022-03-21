using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp.Classes
{
    internal class FileIO
    {
        public static string ReadLocaleFromFile(string filename)
        {
            string fullpath = Directory.GetCurrentDirectory() + "\\" + filename;

            if (File.Exists(fullpath))
            {
                // read default city from file
                // deserialize JSON from a file
                Locale locale = JsonConvert.DeserializeObject<Locale>(File.ReadAllText(fullpath));
                
                return locale.City;
            }
            else
            {
                return String.Empty;
            }

             
        }

        public static async void WriteCityToJSON(Locale locale, string filename)
        {
            // get current application directory.
            string fullPath = Directory.GetCurrentDirectory() + "\\" + filename;

            // write locale to json file in app directory
            string json = JsonConvert.SerializeObject(locale, Formatting.Indented);
            await File.WriteAllTextAsync(fullPath, json);

        }


        public class Locale
        {
            public string City { get; set; }
        }

    }
}
