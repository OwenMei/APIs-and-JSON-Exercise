using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static string GetWeather(string location)
        {
            HttpClient client = new HttpClient();
            string city = location;
            var weatherAPI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=b9defe8f16210960fbebbdebf9a00ed8";
            var gotTemp = client.GetStringAsync(weatherAPI).Result;

            var getTheCity = JObject.Parse(gotTemp).GetValue("main");
            double temperature = Math.Round((1.8 * (getTheCity.Value<double>("temp") - 273.15) + 32), 2);
            return temperature.ToString();
        }
        

    }
}
