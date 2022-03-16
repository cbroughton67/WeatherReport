using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WeatherApp.Classes
{
    public class WeatherMail
    {
        public static void SendEmail(string userEmail, dynamic forecastData)
        { 
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("weathermonkeyconsole@gmail.com"); // the weather monkey email account
                mail.To.Add(userEmail); // the email user entered
                mail.Subject = "Weather Monkey Forecast";
                mail.IsBodyHtml = true; 
                mail.Body = "<hr style =\"width:50%;text-align:left;margin-left:0\">"; //HTML Header
                mail.Body += "<h1 style=\"width:50%;text-align:center;\">WEATHER MONKEY</h1>";
                mail.Body += "<hr style=\"width:50%;text-align:left;margin-left:0\">";
                mail.Body += "<h2 style=\"text - align:center; \">Forecast for: " + forecastData.resolvedAddress + "</h2>";
                mail.Body += "<table>";  //HTML Table
                mail.Body +=    "<tr><td style=\"padding-right:30px\">Date</td>" + 
                                     "<td style=\"padding-right:30px\">High(F)</td>" +
                                     "<td style=\"padding-right:30px\">Low(F)</td>" +
                                     "<td style=\"padding-right:30px\">Precip(%)</td>" +
                                     "<td style=\"padding-right:30px\">Conditions</td>" +
                                "</tr>";

                foreach (var day in forecastData.days) //HTML formatted table data
                {
                    mail.Body += "<tr><td style=\"padding-right:30px\">" + day.datetime + "</td>" +
                                     "<td style=\"padding-right:30px\">" + day.tempmax  + "F</td>" +
                                     "<td style=\"padding-right:30px\">" + day.tempmin  + "F</td>" +
                                     "<td style=\"padding-right:30px\">" + day.precipprob + "%</td>" +
                                     "<td style=\"padding-right:30px\">" + day.conditions + "</td>" +
                                 "</tr>";
                }

                mail.Body += "</table>";

                using (SmtpClient smtp = new("smtp.gmail.com", 587)) //Send it!
                {
                    // the account and password you just created
                    smtp.Credentials = new NetworkCredential("weathermonkeyconsole@gmail.com", "CodeLou22");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    smtp.Dispose();                                         // dispose of smtp object 
                
                }
                // Verify to user that the email was sent. 
                Console.Write("\n\tForecast has been sent to " + userEmail);
                Console.WriteLine("\n\tPress any key to continue.");
                Console.ReadKey();

                mail.Dispose();                                             // dispose of mail object

            }

            

        }

        public static string GetUserEmail()
        {
            bool isValid;
            string userEmail;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*****                    WEATHER MONKEY                    *****");
            Console.WriteLine("****************************************************************");
            Console.WriteLine();

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            do
            {
                Console.WriteLine("Please enter your email address (or X to exit): ");
                userEmail = Console.ReadLine().Trim();

                //use regex to validate the email format. 
                isValid = regex.IsMatch(userEmail);

                if (!isValid)
                {
                    if (userEmail.ToUpper() == "X") //if user entered "X" then bail. 
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\tEmail format is invalid. Please try again.\n");
                    }
                }

            }
            while (isValid == false); 
            
            return userEmail;
        }
    }
}

