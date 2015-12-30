using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace HaulerTrawler.Eve
{
    public class PriceChecker : IPriceChecker
    {
        public PriceInfo GetPrice(TypeId typeId, SolarSystemId solarSystem)
        {
            var url = string.Format("http://api.eve-central.com/api/marketstat/json?typeid={0}&usesystem={1}", typeId.Id, solarSystem.Id);
            var results = GetJsonArray(url)[0];
            return new PriceInfo((decimal)results.buy.max, (decimal)results.sell.min);
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
