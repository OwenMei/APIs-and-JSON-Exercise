using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static string GetWeather(string location)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string apiKey = configuration.GetSection("AppSettings")["ApiKey"];

            HttpClient client = new HttpClient();
            
            string city = location;
            var weatherAPI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
            var gotTemp = client.GetStringAsync(weatherAPI).Result;

            var getTheCity = JObject.Parse(gotTemp).GetValue("main");
            double temperature = Math.Round((1.8 * (getTheCity.Value<double>("temp") - 273.15) + 32), 2);
            return temperature.ToString();
        }
        

    }
}
