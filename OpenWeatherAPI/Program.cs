using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace OpenWeatherAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var APIKey = "cc531ad19db46df6368bbf7b807ca7d1"; // Replace with your actual API key

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={APIKey}&units=imperial";
                var response = client.GetStringAsync(weatherURL).Result;
                var weatherData = JObject.Parse(response);

                if (weatherData["main"] is JObject mainData && mainData["temp"] != null)
                {
                    var temp = mainData["temp"];
                    Console.WriteLine($"The current Temperature is {temp} degrees Fahrenheit!");
                }
                else
                {
                    Console.WriteLine("Temperature data not found in the response.");
                }

                AddSpaces(2);
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();
                AddSpaces(2);

                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }
            }
        }
        static void AddSpaces(int numberOfSpaces)
        {
            while (numberOfSpaces != 0)
            {
                Console.WriteLine();
                numberOfSpaces--;
            }
        }
    }
}

