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
    internal class RonVSKanyeAPI
    {
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
