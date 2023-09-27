using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static void ConvoAsync()
        {
            for (int i = 0; i < 6; i++)
            {

                HttpClient client = new HttpClient();
                string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
                var ronReponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronReponse);
                string kanyeURL = "https://api.kanye.rest/";
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse);
                Console.WriteLine("Ron Swanson: " + ronQuote);
                Console.WriteLine("Kanye West: " + kanyeQuote);
                Console.WriteLine();
            }
        }
    }
}
