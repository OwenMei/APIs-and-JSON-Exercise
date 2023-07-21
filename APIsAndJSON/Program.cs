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
                Console.WriteLine("Ron: " + RonVSKanyeAPI.RonQuote());
                Console.WriteLine("Kanye: " + RonVSKanyeAPI.KanyeQuote());
            }

            Console.WriteLine("\n\n\nWhat city would you like to know the temperature of?");
            string city = Console.ReadLine();

            Console.WriteLine($"In {city}, it is currently {OpenWeatherMapAPI.GetWeather(city)} degrees fahreinheit");
        }
    }
}
