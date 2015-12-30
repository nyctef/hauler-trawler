using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace HaulerTrawler.Eve
{
    public class SolarSystemRouteFinder : ISolarSystemRouteFinder
    {
        public int GetNumberOfJumps(SolarSystemId start, SolarSystemId end)
        {
            var url = string.Format("http://api.eve-central.com/api/route/from/{0}/to/{1}", start.Id, end.Id);
            // the route api gives us a json array of the jumps required, so just count those
            return GetJsonArray(url).Count;
        }
        
        private static dynamic GetJsonArray(string url)
        {
            using (var client = new HttpClient())
            {
                // TODO async
                var json = client.GetStringAsync(url).Result;
                return JArray.Parse(json);
            }
        }
    }
}
