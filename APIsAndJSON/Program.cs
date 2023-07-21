using System.Text.Json.Nodes;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Ron: " + RonQuote());
                Console.WriteLine("Kanye: " + KanyeQuote());
            }
            
            
        }

        public static string RonQuote()
        {
            HttpClient client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;

            var ronObject = JArray.Parse(ronResponse)[0];
            return ronObject.ToString();
        }

        public static string KanyeQuote()
        {
            HttpClient client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            var kanyeObject = JObject.Parse(kanyeResponse).GetValue("quote");
            return kanyeObject.ToString();
        }
    }
}
